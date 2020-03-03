using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieValidator
{
    public class CreateBijouterieModelValidatorTest
    {
        private readonly CreateBijouterieModelValidator _validator;

        public CreateBijouterieModelValidatorTest()
        {
            _validator = new CreateBijouterieModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Validate_NameNotEmpty_SuccessfulValidation(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Validate_NameDefault_FailedValidation()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Validate_NameMaxLength_FailedValidation()
        {
            string name = new string('n', 129);
            _validator.ShouldHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Validate_BrandIdGreaterThanZero_SuccessfulValidation()
        {
            int brandId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.BrandId, brandId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_BrandIdLessThenOrEqualToZero_FailedValidation(int brandId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BrandId, brandId);
        }

        [Fact]
        public void Validate_CountryIdGreaterThanZero_SuccessfulValidation()
        {
            int countryId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, countryId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_CountryIdLessThenOrEqualToZero_FailedValidation(int countryId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.CountryId, countryId);
        }

        [Fact]
        public void Validate_CostGreaterThanZero_SuccessfulValidation()
        {
            int cost = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Cost, cost);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_CostLessThenOrEqualToZero_FailedValidation(int cost)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Cost, cost);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Validate_AmountGreaterOrEqualToZero_SuccessfulValidation(int amount)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Amount, amount);
        }

        [Fact]
        public void Validate_AmountLessThenZero_FailedValidation()
        {
            int amount = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.Amount, amount);
        }

        [Fact]
        public void Validate_BijouterieTypeIdGreaterThanZero_SuccessfulValidation()
        {
            int bijouterieTypeId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.BijouterieTypeId, bijouterieTypeId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_BijouterieTypeIdLessThenOrEqualToZero_FailedValidation(int bijouterieTypeId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BijouterieTypeId, bijouterieTypeId);
        }
    }
}
