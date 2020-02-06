using FluentValidation;

namespace JewelryStoreAPI.Presentations.Role.Validators
{
    public class CreateRoleModelValidator : AbstractValidator<CreateRoleModel>
    {
        public CreateRoleModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
