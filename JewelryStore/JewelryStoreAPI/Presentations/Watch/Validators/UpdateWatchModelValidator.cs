using FluentValidation;
using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Presentations.Watch.Validators
{
    public class UpdateWatchModelValidator : AbstractValidator<UpdateWatchModel>
    {
        public UpdateWatchModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(128).NotNull();
            RuleFor(x => x.BrandId).GreaterThan(0);
            RuleFor(x => x.CountryId).GreaterThan(0);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Diameter).GreaterThan(0);
            RuleFor(x => x.CaseColor).MaximumLength(32).NotNull().IsEnumName(typeof(Color));
            RuleFor(x => x.DialColor).MaximumLength(32).NotNull().IsEnumName(typeof(Color));
            RuleFor(x => x.StrapColor).MaximumLength(32).NotNull().IsEnumName(typeof(Color));
        }
    }
}
