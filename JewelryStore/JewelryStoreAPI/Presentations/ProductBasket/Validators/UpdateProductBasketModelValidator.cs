using FluentValidation;

namespace JewelryStoreAPI.Presentations.ProductBasket.Validators
{
    public class UpdateProductBasketModelValidator : AbstractValidator<UpdateProductBasketModel>
    {
        public UpdateProductBasketModelValidator()
        {
            RuleFor(x => x.ProductCount).GreaterThan(0);
        }
    }
}
