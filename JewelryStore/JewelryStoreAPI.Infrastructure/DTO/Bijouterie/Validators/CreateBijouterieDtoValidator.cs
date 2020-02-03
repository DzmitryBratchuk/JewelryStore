using FluentValidation;

namespace JewelryStoreAPI.Infrastructure.DTO.Bijouterie.Validators
{
    public class CreateBijouterieDtoValidator : AbstractValidator<CreateBijouterieDto>
    {
        public CreateBijouterieDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(128).NotNull();
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.BijouterieTypeId).NotEmpty();
        }
    }
}
