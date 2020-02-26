using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Order;
using System.Collections.Generic;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.OrderValidator
{
    public class CreateOrderModelValidatorTester
    {
        private readonly CreateOrderModelValidator _validator;

        public CreateOrderModelValidatorTester()
        {
            _validator = new CreateOrderModelValidator();
        }

        [Fact]
        public void Should_not_have_error_ProductIds()
        {
            IList<int> productIds = new List<int>() { 1, 2, 3, 4 };
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Should_have_error_ProductIds_empty()
        {
            IList<int> productIds = new List<int>() { };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Should_have_error_ProductIds_lessThenZero()
        {
            IList<int> productIds = new List<int>() { -1, 1, 2, 3 };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Should_have_error_ProductIds_equalToZero()
        {
            IList<int> productIds = new List<int>() { 0, 1, 2, 3 };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }
    }
}
