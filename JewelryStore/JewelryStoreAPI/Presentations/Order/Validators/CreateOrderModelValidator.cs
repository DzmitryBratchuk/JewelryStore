using FluentValidation;

namespace JewelryStoreAPI.Presentations.Order.Validators
{
    public class CreateOrderModelValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderModelValidator()
        {
            RuleFor(x => x.ProductIds).NotEmpty();
        }
    }
}
