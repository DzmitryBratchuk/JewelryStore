using FluentValidation;
using JewelryStoreAPI.Models.Role;

namespace JewelryStoreAPI.Validators.Role
{
    public class UpdateRoleModelValidator : AbstractValidator<UpdateRoleModel>
    {
        public UpdateRoleModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
