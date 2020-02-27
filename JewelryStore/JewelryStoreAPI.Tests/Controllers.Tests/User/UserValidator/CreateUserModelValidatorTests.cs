using FluentValidation.TestHelper;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class CreateUserModelValidatorTests
    {
        private readonly CreateUserModelValidator _validator;

        public CreateUserModelValidatorTests()
        {
            _validator = new CreateUserModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Should_Not_Have_Error_FirstName_NotNull(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Fact]
        public void Should_Have_Error_FirstName_Default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Fact]
        public void Should_Have_Error_FirstName_MaxLength()
        {
            string name = new string('n', 65);
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Should_Not_Have_Error_LastName_NotNull(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.LastName, name);
        }

        [Fact]
        public void Should_Have_Error_LastName_Default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, name);
        }

        [Fact]
        public void Should_Have_Error_LastName_MaxLength()
        {
            string name = new string('n', 65);
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, name);
        }

        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test.123@aa-a.aa")]
        public void Should_Not_Have_Error_Login_ValidTemplate(string login)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Login, login);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        [InlineData("test@aaa.a$")]
        [InlineData("test.123@aa-a.aa-")]
        public void Should_Have_Error_Login_InvalidTemplate(string login)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }

        [Fact]
        public void Should_Have_Error_Login_Default()
        {
            string login = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }

        [Fact]
        public void Should_Not_Have_Error_RoleId_GreaterThanZero()
        {
            int roleId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_RoleId_LessThenOrEqualToZero(int roleId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Fact]
        public void Should_Not_Have_Error_Password_EqualPasswords()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_Have_Error_Password_MinLenght()
        {
            var model = new CreateUserModel()
            {
                Password = "Test_pa",
                ConfirmPassword = "Test_pa"
            };

            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_Have_Error_Password_UnequalPasswords()
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
