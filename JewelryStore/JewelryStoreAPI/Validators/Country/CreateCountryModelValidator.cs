using FluentValidation;
using JewelryStoreAPI.Models.Country;

namespace JewelryStoreAPI.Validators.Country
{
    public class CreateCountryModelValidator : AbstractValidator<CreateCountryModel>
    {
        public CreateCountryModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
