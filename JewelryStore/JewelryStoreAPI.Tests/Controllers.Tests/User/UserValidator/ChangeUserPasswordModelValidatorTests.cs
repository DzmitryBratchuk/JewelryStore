using FluentValidation.TestHelper;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class ChangeUserPasswordModelValidatorTests
    {
        private readonly ChangeUserPasswordModelValidator _validator;

        public ChangeUserPasswordModelValidatorTests()
        {
            _validator = new ChangeUserPasswordModelValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_NewPassword_EqualPasswords()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_password",
                ConfirmNewPassword = "Test_password"
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_Have_Error_NewPassword_MinLenght()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_pa",
                ConfirmNewPassword = "Test_pa"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_Have_Error_NewPassword_UnequalPasswords()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_password",
                ConfirmNewPassword = "TEST_password"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
        }
    }
}
