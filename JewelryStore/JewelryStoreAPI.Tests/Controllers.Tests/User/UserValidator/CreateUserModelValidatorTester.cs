using FluentValidation.TestHelper;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class CreateUserModelValidatorTester
    {
        private readonly CreateUserModelValidator _validator;

        public CreateUserModelValidatorTester()
        {
            _validator = new CreateUserModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Should_not_have_error_FirstName(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Fact]
        public void Should_have_error_FirstName_default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Fact]
        public void Should_have_error_FirstName_maxLength()
        {
            string name = new string('n', 65);
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Should_not_have_error_LastName(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.LastName, name);
        }

        [Fact]
        public void Should_have_error_LastName_default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, name);
        }

        [Fact]
        public void Should_have_error_LastName_maxLength()
        {
            string name = new string('n', 65);
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, name);
        }

        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test.123@aa-a.aa")]
        public void Should_not_have_error_Login(string login)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Login, login);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        [InlineData("test@aaa.a$")]
        [InlineData("test.123@aa-a.aa-")]
        public void Should_have_error_Login_maxLength(string login)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }

        [Fact]
        public void Should_have_error_Login_default()
        {
            string login = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }

        [Fact]
        public void Should_not_have_error_RoleId()
        {
            int roleId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_RoleId_lessThenOrEqualToZero(int roleId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Fact]
        public void Should_not_have_error_Password()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_have_error_Password_minLenght()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_pa",
                ConfirmPassword = "Test_pa"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_have_error_Password_confirmPassword()
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
