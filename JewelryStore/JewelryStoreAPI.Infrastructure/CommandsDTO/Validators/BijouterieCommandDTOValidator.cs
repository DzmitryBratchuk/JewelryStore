using FluentValidation;

namespace JewelryStoreAPI.Infrastructure.CommandsDTO.Validators
{
    public class BijouterieCommandDTOValidator : AbstractValidator<BijouterieCommandDTO>
    {
        public BijouterieCommandDTOValidator()
        {
            RuleFor(x => x.Name).MaximumLength(128).NotNull();
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.BijouterieTypeId).NotEmpty();
        }
    }
}
