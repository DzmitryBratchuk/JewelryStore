using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class RemoveUserModelValidatorTest
    {
        private readonly RemoveUserModelValidator _validator;

        public RemoveUserModelValidatorTest()
        {
            _validator = new RemoveUserModelValidator();
        }

        [Fact]
        public void Validate_IdGreaterThanZero_SuccessfulValidation()
        {
            int id = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_IdLessThenOrEqualToZero_FailedValidation(int id)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Id, id);
        }
    }
}
