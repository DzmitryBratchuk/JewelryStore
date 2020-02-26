using FluentValidation;
using JewelryStoreAPI.Models.Role;

namespace JewelryStoreAPI.Validators.Role
{
    public class RemoveRoleModelValidator : AbstractValidator<RemoveRoleModel>
    {
        public RemoveRoleModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
