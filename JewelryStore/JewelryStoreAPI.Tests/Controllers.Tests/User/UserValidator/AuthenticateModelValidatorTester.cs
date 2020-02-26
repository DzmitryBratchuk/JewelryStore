using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class AuthenticateModelValidatorTester
    {
        private readonly AuthenticateModelValidator _validator;

        public AuthenticateModelValidatorTester()
        {
            _validator = new AuthenticateModelValidator();
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
    }
}
