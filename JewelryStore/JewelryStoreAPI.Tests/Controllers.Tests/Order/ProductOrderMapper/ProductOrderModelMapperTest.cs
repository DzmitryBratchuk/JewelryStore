using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using JewelryStoreAPI.Models.ProductOrder;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.ProductOrderMapper
{
    public class ProductOrderModelMapperTest
    {
        private readonly IMapper _mapper;

        public ProductOrderModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_ProductOrderDtoToProductOrderModel_SuccessfulMapping()
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
    }
}
