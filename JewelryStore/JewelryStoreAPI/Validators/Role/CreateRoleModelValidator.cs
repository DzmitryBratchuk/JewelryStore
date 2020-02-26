using FluentValidation;
using JewelryStoreAPI.Models.Role;

namespace JewelryStoreAPI.Validators.Role
{
    public class CreateRoleModelValidator : AbstractValidator<CreateRoleModel>
    {
        public CreateRoleModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
