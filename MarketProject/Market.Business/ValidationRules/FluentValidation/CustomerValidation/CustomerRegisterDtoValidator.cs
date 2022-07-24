using FluentValidation;
using Market.Entities.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.ValidationRules.FluentValidation.CustomerValidation
{
    internal class CustomerRegisterDtoValidator:AbstractValidator<CustomerRegisterDto>
    {
        public CustomerRegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim alanı zorunludur."); ;
            RuleFor(u => u.FirstName).MaximumLength(100);
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim alanı zorunludur."); ;
            RuleFor(u => u.LastName).MaximumLength(100);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.EmailAddress).NotEmpty().WithMessage("E-Posta Adresi alanı zorunludur.");
            RuleFor(u => u.EmailAddress).Length(10, 100).WithMessage("E-Posta Adresi alanı en az 10 en fazla 100 karakter olmalıdır");
        }
    }
}
