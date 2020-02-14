using FluentValidation;
using JewelryStoreAPI.Models.User;

namespace JewelryStoreAPI.Validators.User
{
    public class ChangeUserRoleModelValidator : AbstractValidator<ChangeUserRoleModel>
    {
        public ChangeUserRoleModelValidator()
        {
            RuleFor(x => x.RoleId).GreaterThan(0);
        }
    }
}
