using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket.ProductBasketMapper
{
    using Entities = Domain.Entities;

    public class AddProductInBasketDtoMapperTester
    {
        private readonly IMapper _mapper;

        public AddProductInBasketDtoMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_AddProductInBasketDto_to_ProductBasket()
        {
            var source = new AddProductInBasketDto()
            {
                ProductId = 1,
                ProductCount = 1
            };

            var destination = _mapper.Map<Entities.ProductBasket>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCount);
        }

        [Fact]
        public void Should_not_have_error_AddProductInBasketDto_to_ProductBasket_DefaultProperty()
        {
            var source = new AddProductInBasketDto()
            {
                ProductId = default,
                ProductCount = default
            };

            var destination = _mapper.Map<Entities.ProductBasket>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCount);
        }
    }
}
