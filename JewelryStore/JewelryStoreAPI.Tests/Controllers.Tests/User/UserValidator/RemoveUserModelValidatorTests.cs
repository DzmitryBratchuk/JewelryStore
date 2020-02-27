using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class RemoveUserModelValidatorTests
    {
        private readonly RemoveUserModelValidator _validator;

        public RemoveUserModelValidatorTests()
        {
            _validator = new RemoveUserModelValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_Id_GreaterThanZero()
        {
            int id = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_Id_LessThenOrEqualToZero(int id)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Id, id);
        }
    }
}
