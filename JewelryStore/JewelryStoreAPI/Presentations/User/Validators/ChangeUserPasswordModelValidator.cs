using FluentValidation;

namespace JewelryStoreAPI.Presentations.User.Validators
{
    public class ChangeUserPasswordModelValidator : AbstractValidator<ChangeUserPasswordModel>
    {
        public ChangeUserPasswordModelValidator()
        {
            RuleFor(x => x.NewPassword).MinimumLength(8).Equal(x => x.ConfirmNewPassword);
        }
    }
}
