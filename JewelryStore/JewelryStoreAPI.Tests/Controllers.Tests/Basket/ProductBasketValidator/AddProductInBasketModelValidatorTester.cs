using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class AddProductInBasketModelValidatorTester
    {
        private readonly AddProductInBasketModelValidator _validator;

        public AddProductInBasketModelValidatorTester()
        {
            _validator = new AddProductInBasketModelValidator();
        }

        [Fact]
        public void Should_not_have_error_ProductId()
        {
            int productId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductId, productId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_ProductId_lessThenOrEqualToZero(int brandId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, brandId);
        }

        [Fact]
        public void Should_not_have_error_ProductCount()
        {
            int productCount = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductCount, productCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_ProductCount_lessThenOrEqualToZero(int productCount)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductCount, productCount);
        }
    }
}
