using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class RemoveUserModelValidatorTester
    {
        private readonly RemoveUserModelValidator _validator;

        public RemoveUserModelValidatorTester()
        {
            _validator = new RemoveUserModelValidator();
        }

        [Fact]
        public void Should_not_have_error_Id()
        {
            int id = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_Id_lessThenOrEqualToZero(int id)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Id, id);
        }
    }
}
