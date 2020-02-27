using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class AuthenticateModelValidatorTests
    {
        private readonly AuthenticateModelValidator _validator;

        public AuthenticateModelValidatorTests()
        {
            _validator = new AuthenticateModelValidator();
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
    }
}
