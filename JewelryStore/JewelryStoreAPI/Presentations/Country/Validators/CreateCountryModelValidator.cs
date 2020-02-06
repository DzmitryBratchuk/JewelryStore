using FluentValidation;

namespace JewelryStoreAPI.Presentations.Country.Validators
{
    public class CreateCountryModelValidator : AbstractValidator<CreateCountryModel>
    {
        public CreateCountryModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
