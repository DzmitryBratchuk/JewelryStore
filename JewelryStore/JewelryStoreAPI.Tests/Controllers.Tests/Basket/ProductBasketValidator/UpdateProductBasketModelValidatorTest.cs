using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class UpdateProductBasketModelValidatorTest
    {
        private readonly UpdateProductBasketModelValidator _validator;

        public UpdateProductBasketModelValidatorTest()
        {
            _validator = new UpdateProductBasketModelValidator();
        }

        [Fact]
        public void Validate_ProductIdGreaterThanZero_SuccessfulValidation()
        {
            int productCount = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductCount, productCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_ProductIdLessThenOrEqualToZero_FailedValidation(int productCount)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductCount, productCount);
        }
    }
}
