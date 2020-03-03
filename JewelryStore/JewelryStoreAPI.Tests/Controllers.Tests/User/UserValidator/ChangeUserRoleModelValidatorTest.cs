using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserValidator
{
    public class ChangeUserRoleModelValidatorTest
    {
        private readonly ChangeUserRoleModelValidator _validator;

        public ChangeUserRoleModelValidatorTest()
        {
            _validator = new ChangeUserRoleModelValidator();
        }

        [Fact]
        public void Validate_RoleIdGreaterThanZero_SuccessfulValidation()
        {
            int roleId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.RoleId, roleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_RoleIdLessThenOrEqualToZero_FailedValidation(int roleId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.RoleId, roleId);
        }
    }
}
