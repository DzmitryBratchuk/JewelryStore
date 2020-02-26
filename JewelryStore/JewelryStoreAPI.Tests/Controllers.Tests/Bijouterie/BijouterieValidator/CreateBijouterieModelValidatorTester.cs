using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieValidator
{
    public class CreateBijouterieModelValidatorTester
    {
        private readonly CreateBijouterieModelValidator _validator;

        public CreateBijouterieModelValidatorTester()
        {
            _validator = new CreateBijouterieModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Should_not_have_error_Name(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Should_have_error_Name_default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Should_have_error_Name_maxLength()
        {
            string name = new string('n', 129);
            _validator.ShouldHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Should_not_have_error_BrandId()
        {
            int brandId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.BrandId, brandId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_BrandId_lessThenOrEqualToZero(int brandId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BrandId, brandId);
        }

        [Fact]
        public void Should_not_have_error_CountryId()
        {
            int countryId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, countryId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_CountryId_lessThenOrEqualToZero(int countryId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.CountryId, countryId);
        }

        [Fact]
        public void Should_not_have_error_Cost()
        {
            int cost = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Cost, cost);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_Cost_lessThenOrEqualToZero(int cost)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Cost, cost);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Should_not_have_error_Amount(int amount)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Amount, amount);
        }

        [Fact]
        public void Should_have_error_Amount_lessThenZero()
        {
            int amount = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.Amount, amount);
        }

        [Fact]
        public void Should_not_have_error_BijouterieTypeId()
        {
            int bijouterieTypeId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.BijouterieTypeId, bijouterieTypeId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_have_error_BijouterieTypeId_lessThenOrEqualToZero(int bijouterieTypeId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BijouterieTypeId, bijouterieTypeId);
        }
    }
}
