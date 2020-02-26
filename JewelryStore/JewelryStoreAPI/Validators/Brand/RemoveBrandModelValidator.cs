using FluentValidation;
using JewelryStoreAPI.Models.Brand;

namespace JewelryStoreAPI.Validators.Brand
{
    public class RemoveBrandModelValidator : AbstractValidator<RemoveBrandModel>
    {
        public RemoveBrandModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
