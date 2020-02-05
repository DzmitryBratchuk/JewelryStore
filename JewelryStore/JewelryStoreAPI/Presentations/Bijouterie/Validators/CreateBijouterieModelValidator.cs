using FluentValidation;

namespace JewelryStoreAPI.Presentations.Bijouterie.Validators
{
    public class CreateBijouterieModelValidator : AbstractValidator<CreateBijouterieModel>
    {
        public CreateBijouterieModelValidator()
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
