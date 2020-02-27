using FluentValidation.TestHelper;
using JewelryStoreAPI.Validators.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieValidator
{
    public class CreateBijouterieModelValidatorTests
    {
        private readonly CreateBijouterieModelValidator _validator;

        public CreateBijouterieModelValidatorTests()
        {
            _validator = new CreateBijouterieModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        public void Should_Not_Have_Error_Name_NotEmpty(string name)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Should_Have_Error_Name_Default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Should_Have_Error_Name_MaxLength()
        {
            string name = new string('n', 129);
            _validator.ShouldHaveValidationErrorFor(x => x.Name, name);
        }

        [Fact]
        public void Should_Not_Have_Error_BrandId_GreaterThanZero()
        {
            int brandId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.BrandId, brandId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_BrandId_LessThenOrEqualToZero(int brandId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BrandId, brandId);
        }

        [Fact]
        public void Should_Not_Have_Error_CountryId_GreaterThanZero()
        {
            int countryId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, countryId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_CountryId_LessThenOrEqualToZero(int countryId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.CountryId, countryId);
        }

        [Fact]
        public void Should_Not_Have_Error_Cost_GreaterThanZero()
        {
            int cost = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Cost, cost);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_Cost_LessThenOrEqualToZero(int cost)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Cost, cost);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Should_Not_Have_Error_Amount_GreaterOrEqualToZero(int amount)
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Amount, amount);
        }

        [Fact]
        public void Should_Have_Error_Amount_LessThenZero()
        {
            int amount = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.Amount, amount);
        }

        [Fact]
        public void Should_Not_Have_Error_BijouterieTypeId_GreaterThanZero()
        {
            int bijouterieTypeId = 1;
            _validator.ShouldNotHaveValidationErrorFor(x => x.BijouterieTypeId, bijouterieTypeId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Error_BijouterieTypeId_LessThenOrEqualToZero(int bijouterieTypeId)
        {
            _validator.ShouldHaveValidationErrorFor(x => x.BijouterieTypeId, bijouterieTypeId);
        }
    }
}
