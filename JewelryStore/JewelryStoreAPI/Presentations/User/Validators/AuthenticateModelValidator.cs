using FluentValidation;

namespace JewelryStoreAPI.Presentations.User.Validators
{
    public class AuthenticateModelValidator : AbstractValidator<AuthenticateModel>
    {
        public AuthenticateModelValidator()
        {
            RuleFor(x => x.Login).EmailAddress();
        }
    }
}
