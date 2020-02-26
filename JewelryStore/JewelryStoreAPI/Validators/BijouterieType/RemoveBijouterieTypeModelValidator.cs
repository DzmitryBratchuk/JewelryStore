using FluentValidation;
using JewelryStoreAPI.Models.BijouterieType;

namespace JewelryStoreAPI.Validators.BijouterieType
{
    public class RemoveBijouterieTypeModelValidator : AbstractValidator<RemoveBijouterieTypeModel>
    {
        public RemoveBijouterieTypeModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
