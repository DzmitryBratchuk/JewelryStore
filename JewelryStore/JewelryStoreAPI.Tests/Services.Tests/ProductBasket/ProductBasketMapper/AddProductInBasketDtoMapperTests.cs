using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket.ProductBasketMapper
{
    using Entities = Domain.Entities;

    public class AddProductInBasketDtoMapperTests
    {
        private readonly IMapper _mapper;

        public AddProductInBasketDtoMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_AddProductInBasketDto_To_ProductBasket()
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
    }
}
