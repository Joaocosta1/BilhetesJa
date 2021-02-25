using FluentValidation;
using WebService.ViewModels;
using WebService.ViewModels.Warehouse;

namespace WebService.FluentValidations
{
    public class CreateWarehouseViewModelValidator : AbstractValidator<CreateWarehouseViewModel>
    {
        public CreateWarehouseViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(70);

            RuleFor(x => x.EventId)
                .NotEmpty()
                .NotNull();
        }
    }
}