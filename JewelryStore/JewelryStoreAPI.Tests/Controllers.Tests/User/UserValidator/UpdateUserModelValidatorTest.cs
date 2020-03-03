using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class UpdateUserModelValidatorTest
    {
        private readonly UpdateUserModelValidator _validator;

        public UpdateUserModelValidatorTest()
        {
            _validator = new UpdateUserModelValidator();
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
        public void Validate_LastNamedefault_FailedValidation()
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
    }
}
