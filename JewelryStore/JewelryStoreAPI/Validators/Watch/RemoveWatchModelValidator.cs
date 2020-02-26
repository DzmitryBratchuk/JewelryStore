using FluentValidation;
using JewelryStoreAPI.Models.Watch;

namespace JewelryStoreAPI.Validators.Watch
{
    public class RemoveWatchModelValidator : AbstractValidator<RemoveWatchModel>
    {
        public RemoveWatchModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
