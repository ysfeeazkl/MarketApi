using FluentValidation;
using Market.Entities.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.ValidationRules.FluentValidation.CustomerValidation
{
    internal class CustomerLoginDtoValidator:AbstractValidator<CustomerLoginDto>
    {
        public CustomerLoginDtoValidator()
        {
            RuleFor(c => c.EmailAddress).NotEmpty().WithMessage("E-Posta Adresi alanı zorunludur.");
            RuleFor(c => c.EmailAddress).Length(10, 100).WithMessage("E-Posta Adresi alanı en az 10 en fazla 100 karakter olmalıdır");
            RuleFor(c=>c.Password).NotEmpty().WithMessage("Şifre alanı zorunludur.");

        }
    }
}
