using FluentValidation;
using JewelryStoreAPI.Models.Bijouterie;

namespace JewelryStoreAPI.Validators.Bijouterie
{
    public class RemoveBijouterieModelValidator : AbstractValidator<RemoveBijouterieModel>
    {
        public RemoveBijouterieModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
