using FluentValidation.TestHelper;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class CreateUserModelValidatorTest
    {
        private readonly CreateUserModelValidator _validator;

        public CreateUserModelValidatorTest()
        {
            _validator = new CreateUserModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Validate_FirstNameNotNull_SuccessfulValidation(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Fact]
        public void Validate_FirstNameDefault_FailedValidation()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Fact]
        public void Validate_FirstNameMaxLength_FailedValidation()
        {
            string name = new string('n', 65);
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Validate_LastNameNotNull_SuccessfulValidation(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.LastName, name);
        }

        [Fact]
        public void Validate_LastNameDefault_FailedValidation()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, name);
        }

        [Fact]
        public void Validate_LastNameMaxLength_FailedValidation()
        {
            string name = new string('n', 65);
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, name);
        }

        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test.123@aa-a.aa")]
        public void Validate_LoginValidTemplate_SuccessfulValidation(string login)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Login, login);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        [InlineData("test@aaa.a$")]
        [InlineData("test.123@aa-a.aa-")]
        public void Validate_LoginInvalidTemplate_FailedValidation(string login)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }

        [Fact]
        public void Validate_LoginDefault_FailedValidation_FailedValidation()
        {
            string login = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }

        [Fact]
        public void Validate_RoleIdGreaterThanZero_SuccessfulValidation()
        {
            int roleId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_RoleIdLessThenOrEqualToZero_FailedValidation(int roleId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Fact]
        public void Validate_PasswordEqualToConfirmPassword_SuccessfulValidation()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Validate_PasswordMinLenght_FailedValidation()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_pa",
                ConfirmPassword = "Test_pa"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Validate_PasswordUnequalToConfirmPassword_FailedValidation()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_password",
                ConfirmPassword = "TEST_password"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
        }
    }
}
