using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be valid");

            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Password is required")
                .Must(val => PasswordConstrains(val)).WithMessage("must conatin 8+ chars, must include a lowercase, an uppercase and a digit");

            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Person Name is required")
                .Length(5, 25).WithMessage("Person Name must conatins minimu 5 and maximum 25 character");

            RuleFor(mode => mode.Gender)
                .IsInEnum().WithMessage("Gender must be Male, Female or Other");

        }

        bool PasswordConstrains(string Password)
        {
            var re = new System.Text.RegularExpressions.Regex(@"^(?=.{8,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$");
            
            return re.IsMatch(Password);
        }

    }
}
