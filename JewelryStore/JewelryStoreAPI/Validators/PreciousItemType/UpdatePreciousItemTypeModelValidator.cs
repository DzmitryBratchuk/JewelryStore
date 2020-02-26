using FluentValidation;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Models.PreciousItemType;

namespace JewelryStoreAPI.Validators.PreciousItemType
{
    public class UpdatePreciousItemTypeModelValidator : AbstractValidator<UpdatePreciousItemTypeModel>
    {
        public UpdatePreciousItemTypeModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
            RuleFor(x => x.MetalType).MaximumLength(32).NotNull().IsEnumName(typeof(MetalType));
        }
    }
}
