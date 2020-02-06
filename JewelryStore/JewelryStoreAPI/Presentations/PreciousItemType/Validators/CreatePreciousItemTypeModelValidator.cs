using FluentValidation;
using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Presentations.PreciousItemType.Validators
{
    public class CreatePreciousItemTypeModelValidator : AbstractValidator<CreatePreciousItemTypeModel>
    {
        public CreatePreciousItemTypeModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
            RuleFor(x => x.MetalType).MaximumLength(32).NotNull().IsEnumName(typeof(MetalType));
        }
    }
}
