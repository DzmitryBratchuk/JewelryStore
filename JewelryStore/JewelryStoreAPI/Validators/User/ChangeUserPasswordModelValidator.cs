using FluentValidation;
using JewelryStoreAPI.Models.User;

namespace JewelryStoreAPI.Validators.User
{
    public class ChangeUserPasswordModelValidator : AbstractValidator<ChangeUserPasswordModel>
    {
        public ChangeUserPasswordModelValidator()
        {
            RuleFor(x => x.NewPassword).MinimumLength(8).Equal(x => x.ConfirmNewPassword);
        }
    }
}
