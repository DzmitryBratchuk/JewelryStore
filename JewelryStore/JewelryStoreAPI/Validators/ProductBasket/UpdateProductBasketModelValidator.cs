using FluentValidation;
using JewelryStoreAPI.Models.ProductBasket;

namespace JewelryStoreAPI.Validators.ProductBasket
{
    public class UpdateProductBasketModelValidator : AbstractValidator<UpdateProductBasketModel>
    {
        public UpdateProductBasketModelValidator()
        {
            RuleFor(x => x.ProductCount).GreaterThan(0);
        }
    }
}
