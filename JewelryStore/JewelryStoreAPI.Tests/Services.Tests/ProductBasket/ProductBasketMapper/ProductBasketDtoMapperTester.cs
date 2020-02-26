using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket.ProductBasketMapper
{
    using Entities = Domain.Entities;

    public class ProductBasketDtoMapperTester
    {
        private readonly IMapper _mapper;

        public ProductBasketDtoMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ProductBasket_to_ProductBasketDto()
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

        [Fact]
        public void Should_not_have_error_ProductBasket_to_ProductBasketDto_DefaultProperty()
        {
            var source = new Entities.ProductBasket()
            {
                ProductId = default,
                ProductCount = default,
                Product = default
            };

            var destination = _mapper.Map<ProductBasketDto>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCountInBasket);
            Assert.Equal(default, destination.ProductCost);
            Assert.Equal(default, destination.ProductCountInStore);
            Assert.Null(destination.ProductName);
        }
    }
}
