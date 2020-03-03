using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Order;
using System.Collections.Generic;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.OrderValidator
{
    public class CreateOrderModelValidatorTest
    {
        private readonly CreateOrderModelValidator _validator;

        public CreateOrderModelValidatorTest()
        {
            _validator = new CreateOrderModelValidator();
        }

        [Fact]
        public void Validate_ProductIdsGreaterThanZero_SuccessfulValidation()
        {
            IList<int> productIds = new List<int>() { 1, 2, 3, 4 };
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Validate_ProductIdsEmpty_FailedValidation()
        {
            IList<int> productIds = new List<int>() { };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Validate_ProductIdsLessThenZero_FailedValidation()
        {
            IList<int> productIds = new List<int>() { -1, 1, 2, 3 };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }

        [Fact]
        public void Validate_ProductIdsEqualToZer_FailedValidationo()
        {
            IList<int> productIds = new List<int>() { 0, 1, 2, 3 };
            _validator.ShouldHaveValidationErrorFor(x => x.ProductIds, productIds);
        }
    }
}
