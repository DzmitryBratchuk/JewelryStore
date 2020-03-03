using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket.ProductBasketMapper
{
    public class AddProductInBasketDtoMapperTest
    {
        private readonly IMapper _mapper;

        public AddProductInBasketDtoMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_AddProductInBasketDtoToProductBasket_SuccessfulMapping()
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
