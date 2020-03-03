using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class RemoveProductBasketModelValidatorTest
    {
        private readonly RemoveProductBasketModelValidator _validator;

        public RemoveProductBasketModelValidatorTest()
        {
            _validator = new RemoveProductBasketModelValidator();
        }

        [Fact]
        public void Validate_ProductIdGreaterThanZero_SuccessfulValidation()
        {
            int id = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_ProductIdLessThenOrEqualToZero_FailedValidation(int id)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Id, id);
        }
    }
}
