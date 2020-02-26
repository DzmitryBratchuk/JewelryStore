using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using JewelryStoreAPI.Models.ProductOrder;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.ProductOrderMapper
{
    public class ProductOrderModelMapperTester
    {
        private readonly IMapper _mapper;

        public ProductOrderModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ProductOrderDto_to_ProductOrderModel()
        {
            var source = new ProductOrderDto()
            {
                ProductId = 1,
                ProductName = "Test name",
                ProductBrand = "Test brand",
                ProductCountry = "Test country",
                ProductCount = 1,
                ProductCost = 100
            };

            var destination = _mapper.Map<ProductOrderModel>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductName, destination.ProductName);
            Assert.Equal(source.ProductBrand, destination.ProductBrand);
            Assert.Equal(source.ProductCountry, destination.ProductCountry);
            Assert.Equal(source.ProductCount, destination.ProductCount);
            Assert.Equal(source.ProductCost, destination.ProductCost);
        }

        [Fact]
        public void Should_not_have_error_ProductOrderDto_to_ProductOrderModel_DefaultProperty()
        {
            var source = new ProductOrderDto()
            {
                ProductId = default,
                ProductName = default,
                ProductBrand = default,
                ProductCountry = default,
                ProductCount = default,
                ProductCost = default
            };

            var destination = _mapper.Map<ProductOrderModel>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Null(destination.ProductName);
            Assert.Null(destination.ProductBrand);
            Assert.Null(destination.ProductCountry);
            Assert.Equal(source.ProductCount, destination.ProductCount);
            Assert.Equal(source.ProductCost, destination.ProductCost);
        }
    }
}
