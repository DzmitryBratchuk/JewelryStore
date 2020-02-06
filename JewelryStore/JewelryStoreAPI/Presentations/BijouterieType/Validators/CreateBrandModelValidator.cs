using FluentValidation;

namespace JewelryStoreAPI.Presentations.BijouterieType.Validators
{
    public class CreateBijouterieTypeModelValidator : AbstractValidator<CreateBijouterieTypeModel>
    {
        public CreateBijouterieTypeModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
