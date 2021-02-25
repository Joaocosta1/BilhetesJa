using FluentValidation;
using WebService.ViewModels;
using WebService.ViewModels.PaymentType;

namespace WebService.FluentValidations
{
    public class CreatePaymentTypeViewModelValidator : AbstractValidator<CreatePaymentTypeViewModel>
    {
        public CreatePaymentTypeViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(70);

            RuleFor(x => x.Tax)
                .NotNull()
                .InclusiveBetween(0, 100);

            RuleFor(x => x.EventId)
                .NotNull()
                .NotEmpty();
        }
    }
}