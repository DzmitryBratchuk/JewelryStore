using FluentValidation;

namespace JewelryStoreAPI.Presentations.ProductBasket.Validators
{
    public class AddProductInBasketModelValidator : AbstractValidator<AddProductInBasketModel>
    {
        public AddProductInBasketModelValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.ProductCount).GreaterThan(0);
        }
    }
}
