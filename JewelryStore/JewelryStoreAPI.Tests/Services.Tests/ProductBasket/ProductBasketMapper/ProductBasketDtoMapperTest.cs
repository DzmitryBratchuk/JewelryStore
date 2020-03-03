using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket.ProductBasketMapper
{
    public class ProductBasketDtoMapperTest
    {
        private readonly IMapper _mapper;

        public ProductBasketDtoMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_ProductBasketToProductBasketDto_SuccessfulMapping()
        {
            var source = new Entities.ProductBasket()
            {
                ProductId = 1,
                ProductCount = 2,
                Product = new Entities.Product
                {
                    Name = "Test name",
                    Cost = 3,
                    Amount = 4
                }
            };

            var destination = _mapper.Map<ProductBasketDto>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCountInBasket);
            Assert.Equal(source.Product.Cost, destination.ProductCost);
            Assert.Equal(source.Product.Amount, destination.ProductCountInStore);
            Assert.Equal(source.Product.Name, destination.ProductName);
        }
    }
}
