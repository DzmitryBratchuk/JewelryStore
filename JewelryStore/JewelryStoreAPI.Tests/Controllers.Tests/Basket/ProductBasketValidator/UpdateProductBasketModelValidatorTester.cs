using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class UpdateProductBasketModelValidatorTester
    {
        private readonly UpdateProductBasketModelValidator _validator;

        public UpdateProductBasketModelValidatorTester()
        {
            _validator = new UpdateProductBasketModelValidator();
        }

        [Fact]
        public void Should_not_have_error_ProductId()
        {
            int productCount = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductCount, productCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_ProductId_lessThenOrEqualToZero(int productCount)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProductCount, productCount);
        }
    }
}
