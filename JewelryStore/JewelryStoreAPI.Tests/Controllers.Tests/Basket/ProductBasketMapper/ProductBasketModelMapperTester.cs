using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class ProductBasketModelMapperTester
    {
        private readonly IMapper _mapper;

        public ProductBasketModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ProductBasketDto_to_ProductBasketModel()
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

        [Fact]
        public void Should_not_have_error_ProductBasketDto_to_ProductBasketModel_DefaultProperty()
        {
            var source = new ProductBasketDto()
            {
                ProductId = default,
                ProductName = default,
                ProductCost = default,
                ProductCountInBasket = default,
                ProductCountInStore = default
            };

            var destination = _mapper.Map<ProductBasketModel>(source);

            Assert.Null(destination.ProductName);
            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCost, destination.ProductCost);
            Assert.Equal(source.ProductCountInBasket, destination.ProductCountInBasket);
            Assert.Equal(source.ProductCountInStore, destination.ProductCountInStore);
        }
    }
}
