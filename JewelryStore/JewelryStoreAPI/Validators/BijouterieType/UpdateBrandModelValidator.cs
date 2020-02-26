using FluentValidation;
using JewelryStoreAPI.Models.BijouterieType;

namespace JewelryStoreAPI.Validators.BijouterieType
{
    public class UpdateBijouterieTypeModelValidator : AbstractValidator<UpdateBijouterieTypeModel>
    {
        public UpdateBijouterieTypeModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
