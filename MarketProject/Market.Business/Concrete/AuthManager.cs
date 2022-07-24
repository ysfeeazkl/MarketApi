using AutoMapper;
using Market.Business.Abstract;
using Market.Business.ValidationRules.FluentValidation.CustomerValidation;
using Market.Data.Concrete.EntityFramework.Context;
using Market.Entities.Concrete;
using Market.Entities.Dtos.CustomerDtos;
using MarketProject.Business.Utilities;
using MarketProject.Shared.Entities.Concrete;
using MarketProject.Shared.Utilities.Exceptions;
using MarketProject.Shared.Utilities.Hashing;
using MarketProject.Shared.Utilities.Results.Abstract;
using MarketProject.Shared.Utilities.Results.ComplexTypes;
using MarketProject.Shared.Utilities.Results.Concrete;
using MarketProject.Shared.Utilities.Security.Jwt;
using MarketProject.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Market.Business.Concrete
{
    public class AuthManager : ManagerBase, IAuthService
    {
        IJwtHelper _jwtHelper;
        public AuthManager(IMapper mapper, MarketContext marketContext, IJwtHelper jwtHelper) : base(mapper, marketContext)
        {
            _jwtHelper = jwtHelper;
        }

        public async Task<IDataResult> RegisterAsync(CustomerRegisterDto customerRegisterDto)
        {
            ValidationTool.Validate(new CustomerRegisterDtoValidator(), customerRegisterDto);

            if (await DbContext.Customers.AnyAsync(c => c.EmailAddress == customerRegisterDto.EmailAddress))
                throw new NotFoundArgumentException(Messages.General.ValidationError(), new Error("Bu e-posta adresine kayıtlı bir kullanıcı mevcut.", "EmailAddress"));

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(customerRegisterDto.Password, out passwordHash, out passwordSalt);
            var customer = Mapper.Map<Customer>(customerRegisterDto);
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            var accessToken = _jwtHelper.CreateToken(customer);
            CustomerToken customerToken = new CustomerToken
            {
                CustomerId = customer.Id,
                Token = accessToken.Token,
                TokenExpiration = accessToken.TokenExpiration,
                CreatedByCustomerId = customer.Id,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                ModifiedByCustomerId = customer.Id,
                IsActive = true,
                IsDeleted = false
            };
            customer.LastLogin = DateTime.Now;
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                DbContext.Customers.Update(customer);
                await DbContext.SaveChangesAsync();
                transactionScope.Complete();
            }

            return new DataResult(ResultStatus.Success, $"{customer.FirstName} " + $"{customer.LastName} hoş geldiniz.", new
            {
                Customer = customer,
                CustomerToken = Mapper.Map<AccessToken>(customerToken)
            });
        }
        public async Task<IDataResult> LoginAsync(CustomerLoginDto customerLoginDto)
        {

            ValidationTool.Validate(new CustomerLoginDtoValidator(), customerLoginDto);


            var customer = await DbContext.Customers.AsNoTracking().SingleOrDefaultAsync(c => c.EmailAddress == customerLoginDto.EmailAddress);
            if (customer == null)
                throw new NotFoundArgumentException(Messages.General.ValidationError(),
                    new Error("Lütfen E-Posta adresinizi veya Şifrenizi kontrol ediniz", "EmailAddress & Password"));

            if (HashingHelper.VerifyPasswordHash(customerLoginDto.Password, customer.PasswordHash, customer.PasswordSalt))
            {
                if (!customer.IsActive)
                    throw new NotFoundArgumentException(Messages.General.ValidationError(), new Error("Giriş  yapabilmek için hesabınızın aktif olması gereklidir", "IsActive"));

                var accessToken = _jwtHelper.CreateToken(customer);
                CustomerToken customerToken = new CustomerToken
                {
                    CustomerId = customer.Id,
                    Token = accessToken.Token,
                    TokenExpiration = accessToken.TokenExpiration,
                    CreatedByCustomerId = customer.Id,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    ModifiedByCustomerId = customer.Id,
                    IsActive = true,
                    IsDeleted = false
                };
                customer.LastLogin = DateTime.Now;
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    DbContext.Customers.Update(customer);
                    await DbContext.SaveChangesAsync();
                    transactionScope.Complete();
                }
                return new DataResult(ResultStatus.Success, $"{customer.FirstName} " + $"{customer.LastName} hoş geldiniz.", new
                {
                    Customer = customer,
                    CustomerToekn = Mapper.Map<AccessToken>(customerToken)
                });
            }


        }
    }
}
