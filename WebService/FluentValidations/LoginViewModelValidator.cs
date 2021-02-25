using FluentValidation;
using WebService.ViewModels;
using WebService.ViewModels.Account;

namespace WebService.FluentValidations
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}