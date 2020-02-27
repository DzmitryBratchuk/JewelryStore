using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class AddProductInBasketModelValidatorTests
    {
        private readonly AddProductInBasketModelValidator _validator;

        public AddProductInBasketModelValidatorTests()
        {
            _validator = new AddProductInBasketModelValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_ProductId_GreaterThanZero()
        {
            int productId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductId, productId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_ProductId_LessThenOrEqualToZero(int brandId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, brandId);
        }

        [Fact]
        public void Should_Not_Have_Error_ProductCount_GreaterThanZero()
        {
            int productCount = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductCount, productCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_ProductCount_LessThenOrEqualToZero(int productCount)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductCount, productCount);
        }
    }
}
