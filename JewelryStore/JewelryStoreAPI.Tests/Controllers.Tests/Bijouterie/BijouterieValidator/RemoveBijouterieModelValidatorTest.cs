using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieValidator
{
    public class RemoveBijouterieModelValidatorTest
    {
        private readonly RemoveBijouterieModelValidator _validator;

        public RemoveBijouterieModelValidatorTest()
        {
            _validator = new RemoveBijouterieModelValidator();
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
