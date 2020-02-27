using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieValidator
{
    public class RemoveBijouterieModelValidatorTests
    {
        private readonly RemoveBijouterieModelValidator _validator;

        public RemoveBijouterieModelValidatorTests()
        {
            _validator = new RemoveBijouterieModelValidator();
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
