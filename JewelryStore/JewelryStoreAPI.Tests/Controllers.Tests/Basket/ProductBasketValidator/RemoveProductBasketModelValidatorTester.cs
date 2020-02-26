using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class RemoveProductBasketModelValidatorTester
    {
        private readonly RemoveProductBasketModelValidator _validator;

        public RemoveProductBasketModelValidatorTester()
        {
            _validator = new RemoveProductBasketModelValidator();
        }

        [Fact]
        public void Should_not_have_error_ProductId()
        {
            int id = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_ProductId_lessThenOrEqualToZero(int id)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Id, id);
        }
    }
}
