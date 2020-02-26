using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class UpdateUserModelValidatorTester
    {
        private readonly UpdateUserModelValidator _validator;

        public UpdateUserModelValidatorTester()
        {
            _validator = new UpdateUserModelValidator();
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
    }
}
