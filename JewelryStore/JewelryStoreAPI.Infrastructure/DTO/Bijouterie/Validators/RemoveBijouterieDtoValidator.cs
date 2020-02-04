using FluentValidation;

namespace JewelryStoreAPI.Infrastructure.DTO.Bijouterie.Validators
{
    public class RemoveBijouterieDtoValidator : AbstractValidator<RemoveBijouterieDto>
    {
        public RemoveBijouterieDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
