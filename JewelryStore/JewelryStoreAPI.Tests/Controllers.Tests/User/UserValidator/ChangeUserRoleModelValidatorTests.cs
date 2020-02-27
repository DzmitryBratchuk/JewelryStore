using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class ChangeUserRoleModelValidatorTests
    {
        private readonly ChangeUserRoleModelValidator _validator;

        public ChangeUserRoleModelValidatorTests()
        {
            _validator = new ChangeUserRoleModelValidator();
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
    }
}
