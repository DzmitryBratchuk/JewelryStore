using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class UpdateProductBasketModelValidatorTests
    {
        private readonly UpdateProductBasketModelValidator _validator;

        public UpdateProductBasketModelValidatorTests()
        {
            _validator = new UpdateProductBasketModelValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_ProductId_GreaterThanZero()
        {
            int productCount = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductCount, productCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_ProductId_LessThenOrEqualToZero(int productCount)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductCount, productCount);
        }
    }
}
