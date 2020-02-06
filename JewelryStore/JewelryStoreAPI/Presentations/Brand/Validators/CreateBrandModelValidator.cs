using FluentValidation;

namespace JewelryStoreAPI.Presentations.Brand.Validators
{
    public class CreateBrandModelValidator : AbstractValidator<CreateBrandModel>
    {
        public CreateBrandModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
