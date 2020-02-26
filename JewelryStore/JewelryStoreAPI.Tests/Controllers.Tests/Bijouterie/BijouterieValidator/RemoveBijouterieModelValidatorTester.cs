using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieValidator
{
    public class RemoveBijouterieModelValidatorTester
    {
        private readonly RemoveBijouterieModelValidator _validator;

        public RemoveBijouterieModelValidatorTester()
        {
            _validator = new RemoveBijouterieModelValidator();
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
