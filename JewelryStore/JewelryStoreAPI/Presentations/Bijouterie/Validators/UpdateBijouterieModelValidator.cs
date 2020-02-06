using FluentValidation;

namespace JewelryStoreAPI.Presentations.Bijouterie.Validators
{
    public class UpdateBijouterieModelValidator : AbstractValidator<UpdateBijouterieModel>
    {
        public UpdateBijouterieModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(128).NotNull();
            RuleFor(x => x.BrandId).GreaterThan(0);
            RuleFor(x => x.CountryId).GreaterThan(0);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BijouterieTypeId).GreaterThan(0);
        }
    }
}
