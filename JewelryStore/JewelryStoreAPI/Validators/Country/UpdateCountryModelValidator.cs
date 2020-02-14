using FluentValidation;
using JewelryStoreAPI.Models.Country;

namespace JewelryStoreAPI.Validators.Country
{
    public class UpdateCountryModelValidator : AbstractValidator<UpdateCountryModel>
    {
        public UpdateCountryModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
