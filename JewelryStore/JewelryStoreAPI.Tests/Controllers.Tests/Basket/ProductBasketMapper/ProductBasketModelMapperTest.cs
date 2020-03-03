using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class ProductBasketModelMapperTest
    {
        private readonly IMapper _mapper;

        public ProductBasketModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_ProductBasketDtoToProductBasketModel_SuccessfulMapping()
        {
            var source = new ProductBasketDto()
            {
                ProductId = 1,
                ProductName = "Test Name",
                ProductCost = 1,
                ProductCountInBasket = 1,
                ProductCountInStore = 1
            };

            var destination = _mapper.Map<ProductBasketModel>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductName, destination.ProductName);
            Assert.Equal(source.ProductCost, destination.ProductCost);
            Assert.Equal(source.ProductCountInBasket, destination.ProductCountInBasket);
            Assert.Equal(source.ProductCountInStore, destination.ProductCountInStore);
        }
    }
}
