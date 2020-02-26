using FluentValidation;
using JewelryStoreAPI.Models.PreciousItem;

namespace JewelryStoreAPI.Validators.PreciousItem
{
    public class UpdatePreciousItemModelValidator : AbstractValidator<UpdatePreciousItemModel>
    {
        public UpdatePreciousItemModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(128).NotNull();
            RuleFor(x => x.BrandId).GreaterThan(0);
            RuleFor(x => x.CountryId).GreaterThan(0);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PreciousItemTypeId).GreaterThan(0);
        }
    }
}
