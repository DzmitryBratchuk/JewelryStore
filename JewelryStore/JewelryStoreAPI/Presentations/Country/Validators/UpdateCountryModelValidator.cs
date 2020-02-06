using FluentValidation;

namespace JewelryStoreAPI.Presentations.Country.Validators
{
    public class UpdateCountryModelValidator : AbstractValidator<UpdateCountryModel>
    {
        public UpdateCountryModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
