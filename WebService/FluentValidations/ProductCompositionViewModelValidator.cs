using FluentValidation;
using WebService.ViewModels;
using WebService.ViewModels.Product;

namespace WebService.FluentValidations
{
    public class ProductCompositionViewModelValidator : AbstractValidator<ProductCompositionViewModel>
    {
        public ProductCompositionViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotNull();
        }
    }
}