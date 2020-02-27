using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class AddProductInBasketModelMapperTests
    {
        private readonly IMapper _mapper;

        public AddProductInBasketModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_AddProductInBasketModel_To_AddProductInBasketDto()
        {
            var source = new AddProductInBasketModel()
            {
                ProductId = 1,
                ProductCount = 1
            };

            var destination = _mapper.Map<AddProductInBasketDto>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCount);
        }
    }
}
