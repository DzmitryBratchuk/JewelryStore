using FluentValidation;
using JewelryStoreAPI.Models.PreciousItemType;

namespace JewelryStoreAPI.Validators.PreciousItemType
{
    public class RemovePreciousItemTypeModelValidator : AbstractValidator<RemovePreciousItemTypeModel>
    {
        public RemovePreciousItemTypeModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
