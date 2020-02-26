using FluentValidation;
using JewelryStoreAPI.Models.Brand;

namespace JewelryStoreAPI.Validators.Brand
{
    public class CreateBrandModelValidator : AbstractValidator<CreateBrandModel>
    {
        public CreateBrandModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
