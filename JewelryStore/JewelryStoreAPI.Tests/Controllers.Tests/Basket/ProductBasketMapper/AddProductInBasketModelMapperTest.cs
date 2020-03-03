using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class AddProductInBasketModelMapperTest
    {
        private readonly IMapper _mapper;

        public AddProductInBasketModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_AddProductInBasketModelToAddProductInBasketDto_SuccessfulMapping()
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
