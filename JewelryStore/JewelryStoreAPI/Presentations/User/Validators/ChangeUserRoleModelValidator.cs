using FluentValidation;

namespace JewelryStoreAPI.Presentations.User.Validators
{
    public class ChangeUserRoleModelValidator : AbstractValidator<ChangeUserRoleModel>
    {
        public ChangeUserRoleModelValidator()
        {
            RuleFor(x => x.RoleId).GreaterThan(0);
        }
    }
}
