using FluentValidation;
using JewelryStoreAPI.Models.BijouterieType;

namespace JewelryStoreAPI.Validators.BijouterieType
{
    public class CreateBijouterieTypeModelValidator : AbstractValidator<CreateBijouterieTypeModel>
    {
        public CreateBijouterieTypeModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
