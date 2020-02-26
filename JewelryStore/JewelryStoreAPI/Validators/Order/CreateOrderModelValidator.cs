using FluentValidation;
using JewelryStoreAPI.Models.Order;

namespace JewelryStoreAPI.Validators.Order
{
    public class CreateOrderModelValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderModelValidator()
        {
            RuleFor(x => x.ProductIds).NotEmpty().ForEach(x => x.GreaterThan(0));
        }
    }
}
