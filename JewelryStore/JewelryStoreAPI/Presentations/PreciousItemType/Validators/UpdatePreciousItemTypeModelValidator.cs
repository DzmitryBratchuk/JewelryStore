using FluentValidation;
using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Presentations.PreciousItemType.Validators
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
