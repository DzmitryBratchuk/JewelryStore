using FluentValidation;
using JewelryStoreAPI.Models.User;

namespace JewelryStoreAPI.Validators.User
{
    public class AuthenticateModelValidator : AbstractValidator<AuthenticateModel>
    {
        public AuthenticateModelValidator()
        {
            RuleFor(x => x.Login).EmailAddress().NotNull();
        }
    }
}
