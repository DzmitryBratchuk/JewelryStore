using FluentValidation;

namespace JewelryStoreAPI.Presentations.BijouterieType.Validators
{
    public class UpdateBijouterieTypeModelValidator : AbstractValidator<UpdateBijouterieTypeModel>
    {
        public UpdateBijouterieTypeModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
