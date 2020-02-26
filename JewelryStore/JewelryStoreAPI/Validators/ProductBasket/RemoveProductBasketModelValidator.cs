using FluentValidation;
using JewelryStoreAPI.Models.ProductBasket;

namespace JewelryStoreAPI.Validators.ProductBasket
{
    public class RemoveProductBasketModelValidator : AbstractValidator<RemoveProductBasketModel>
    {
        public RemoveProductBasketModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
