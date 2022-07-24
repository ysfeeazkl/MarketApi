using Market.Entities.Dtos.CustomerDtos;
using MarketProject.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult> RegisterAsync(CustomerRegisterDto customerRegisterDto);
        Task<IDataResult> LoginAsync(CustomerLoginDto customerLoginDto);
    }
}
