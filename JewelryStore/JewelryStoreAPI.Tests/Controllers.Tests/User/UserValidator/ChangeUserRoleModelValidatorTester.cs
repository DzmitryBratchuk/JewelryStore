using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class ChangeUserRoleModelValidatorTester
    {
        private readonly ChangeUserRoleModelValidator _validator;

        public ChangeUserRoleModelValidatorTester()
        {
            _validator = new ChangeUserRoleModelValidator();
        }

        [Fact]
        public void Should_not_have_error_RoleId()
        {
            int roleId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_RoleId_lessThenOrEqualToZero(int roleId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.RoleId, roleId);
        }
    }
}
