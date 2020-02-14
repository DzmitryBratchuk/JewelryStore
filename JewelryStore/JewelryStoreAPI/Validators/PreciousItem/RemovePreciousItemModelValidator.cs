using FluentValidation;
using JewelryStoreAPI.Models.PreciousItem;

namespace JewelryStoreAPI.Validators.PreciousItem
{
    public class RemovePreciousItemModelValidator : AbstractValidator<RemovePreciousItemModel>
    {
        public RemovePreciousItemModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
