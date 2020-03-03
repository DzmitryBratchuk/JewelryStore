using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class AuthenticateModelValidatorTest
    {
        private readonly AuthenticateModelValidator _validator;

        public AuthenticateModelValidatorTest()
        {
            _validator = new AuthenticateModelValidator();
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
        public void Validate_LoginDefault_FailedValidation()
        {
            string login = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Login, login);
        }
    }
}
