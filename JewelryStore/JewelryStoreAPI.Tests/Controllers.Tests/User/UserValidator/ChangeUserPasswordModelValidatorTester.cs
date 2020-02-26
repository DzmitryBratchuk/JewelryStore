using FluentValidation.TestHelper;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class ChangeUserPasswordModelValidatorTester
    {
        private readonly ChangeUserPasswordModelValidator _validator;

        public ChangeUserPasswordModelValidatorTester()
        {
            _validator = new ChangeUserPasswordModelValidator();
        }

        [Fact]
        public void Should_not_have_error_NewPassword()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_password",
                ConfirmNewPassword = "Test_password"
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_have_error_NewPassword_minLenght()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_pa",
                ConfirmNewPassword = "Test_pa"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_have_error_NewPassword_confirmNewPassword()
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
