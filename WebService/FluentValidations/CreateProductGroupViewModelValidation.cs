using FluentValidation;
using WebService.ViewModels;
using WebService.ViewModels.Event;

namespace WebService.FluentValidations
{
    public class CreateProductGroupViewModelValidation : AbstractValidator<CreateEventViewModel>
    {
        public CreateProductGroupViewModelValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(70);
        }
    }
}