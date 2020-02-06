using FluentValidation;

namespace JewelryStoreAPI.Presentations.Brand.Validators
{
    public class UpdateBrandModelValidator : AbstractValidator<UpdateBrandModel>
    {
        public UpdateBrandModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
