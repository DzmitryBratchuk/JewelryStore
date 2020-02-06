using FluentValidation;

namespace JewelryStoreAPI.Presentations.Role.Validators
{
    public class UpdateRoleModelValidator : AbstractValidator<UpdateRoleModel>
    {
        public UpdateRoleModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(32).NotNull();
        }
    }
}
