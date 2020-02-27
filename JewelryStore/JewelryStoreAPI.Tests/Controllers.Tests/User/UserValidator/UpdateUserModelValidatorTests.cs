using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class UpdateUserModelValidatorTests
    {
        private readonly UpdateUserModelValidator _validator;

        public UpdateUserModelValidatorTests()
        {
            _validator = new UpdateUserModelValidator();
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
        public void Should_Have_Error_LastName_default()
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
    }
}
