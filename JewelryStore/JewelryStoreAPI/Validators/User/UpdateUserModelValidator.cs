using FluentValidation;
using JewelryStoreAPI.Models.User;

namespace JewelryStoreAPI.Validators.User
{
    public class UpdateUserModelValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(64).NotNull();
            RuleFor(x => x.LastName).MaximumLength(64).NotNull();
        }
    }
}
