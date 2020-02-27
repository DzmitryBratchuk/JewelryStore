using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Order;
using System.Collections.Generic;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.OrderValidator
{
    public class CreateOrderModelValidatorTests
    {
        private readonly CreateOrderModelValidator _validator;

        public CreateOrderModelValidatorTests()
        {
            _validator = new CreateOrderModelValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_ProductIds_GreaterThanZero()
        {
            IList<int> productIds = new List<int>() { 1, 2, 3, 4 };
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Should_Have_Error_ProductIds_Empty()
        {
            IList<int> productIds = new List<int>() { };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Should_Have_Error_ProductIds_LessThenZero()
        {
            IList<int> productIds = new List<int>() { -1, 1, 2, 3 };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Should_Have_Error_ProductIds_EqualToZero()
        {
            IList<int> productIds = new List<int>() { 0, 1, 2, 3 };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }
    }
}
