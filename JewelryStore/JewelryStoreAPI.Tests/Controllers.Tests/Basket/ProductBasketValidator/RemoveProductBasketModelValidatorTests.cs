using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketValidator
{
    public class RemoveProductBasketModelValidatorTests
    {
        private readonly RemoveProductBasketModelValidator _validator;

        public RemoveProductBasketModelValidatorTests()
        {
            _validator = new RemoveProductBasketModelValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_ProductId_GreaterThanZero()
        {
            int id = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_ProductId_LessThenOrEqualToZero(int id)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Id, id);
        }
    }
}
