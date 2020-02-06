﻿using FluentValidation;

namespace JewelryStoreAPI.Presentations.User.Validators
{
    public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserModelValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(64).NotNull();
            RuleFor(x => x.LastName).MaximumLength(64).NotNull();
            RuleFor(x => x.Login).EmailAddress();
            RuleFor(x => x.RoleId).GreaterThan(0);
            RuleFor(x => x.Password).MinimumLength(8).Equal(x => x.ConfirmPassword);
        }
    }
}
