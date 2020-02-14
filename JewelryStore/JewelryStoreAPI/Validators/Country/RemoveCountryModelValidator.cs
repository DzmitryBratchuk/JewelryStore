using FluentValidation;
using JewelryStoreAPI.Models.Country;

namespace JewelryStoreAPI.Validators.Country
{
    public class RemoveCountryModelValidator : AbstractValidator<RemoveCountryModel>
    {
        public RemoveCountryModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
