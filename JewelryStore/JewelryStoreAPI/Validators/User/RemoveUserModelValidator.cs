using FluentValidation;
using JewelryStoreAPI.Models.User;

namespace JewelryStoreAPI.Validators.User
{
    public class RemoveUserModelValidator : AbstractValidator<RemoveUserModel>
    {
        public RemoveUserModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
