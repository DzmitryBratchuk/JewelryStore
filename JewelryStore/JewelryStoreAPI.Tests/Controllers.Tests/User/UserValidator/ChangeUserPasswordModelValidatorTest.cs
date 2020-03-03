using FluentValidation.TestHelper;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class ChangeUserPasswordModelValidatorTest
    {
        private readonly ChangeUserPasswordModelValidator _validator;

        public ChangeUserPasswordModelValidatorTest()
        {
            _validator = new ChangeUserPasswordModelValidator();
        }

        [Fact]
        public void Validate_NewPasswordEqualToConfirmNewPassword_SuccessfulValidation()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_password",
                ConfirmNewPassword = "Test_password"
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Validate_NewPasswordMinLenght_FailedValidation()
        {
            var model = new ChangeUserPasswordModel()
            {
                NewPassword = "Test_pa",
                ConfirmNewPassword = "Test_pa"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Validate_NewPasswordUnequalToConfirmNewPassword_FailedValidation()
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
