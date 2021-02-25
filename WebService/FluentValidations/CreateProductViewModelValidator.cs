using FluentValidation;
using WebService.ViewModels;
using WebService.ViewModels.Product;

namespace WebService.FluentValidations
{
    public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(70);

            RuleFor(x => x.EventId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.SalePrice)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PurchasePrice)
                .LessThan(x => x.SalePrice);
            
//            RuleFor(x => x.Composition)
//                .NotNull();

            RuleForEach(x => x.Composition)
                .NotNull()
                .SetValidator(new ProductCompositionViewModelValidator());
        }
    }
}