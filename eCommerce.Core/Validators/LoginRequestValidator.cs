using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Must Enter Valid Email");

            RuleFor(model => model.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
