using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class AddProductInBasketModelValidatorTest
    {
        private readonly AddProductInBasketModelValidator _validator;

        public AddProductInBasketModelValidatorTest()
        {
            _validator = new AddProductInBasketModelValidator();
        }

        [Fact]
        public void Validate_ProductIdGreaterThanZero_SuccessfulValidation()
        {
            int productId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductId, productId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_ProductIdLessThenOrEqualToZero_FailedValidation(int brandId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, brandId);
        }

        [Fact]
        public void Validate_ProductCountGreaterThanZero_SuccessfulValidation()
        {
            int productCount = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductCount, productCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_ProductCountLessThenOrEqualToZero_FailedValidation(int productCount)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductCount, productCount);
        }
    }
}
