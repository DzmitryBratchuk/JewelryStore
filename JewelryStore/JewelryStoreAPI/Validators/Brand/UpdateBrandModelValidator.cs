using FluentValidation;
using JewelryStoreAPI.Models.Brand;

namespace JewelryStoreAPI.Validators.Brand
{
    public class UpdateBrandModelValidator : AbstractValidator<UpdateBrandModel>
    {
        public UpdateBrandModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
