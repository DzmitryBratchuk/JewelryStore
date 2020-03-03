using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class UpdateProductBasketModelMapperTest
    {
        private readonly IMapper _mapper;

        public UpdateProductBasketModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_UpdateProductBasketModelToUpdateProductBasketDto_SuccessfulMapping()
        {
            var source = new UpdateProductBasketModel()
            {
                ProductCount = 1
            };

            var destination = _mapper.Map<UpdateProductBasketDto>(source);

            Assert.Equal(source.ProductCount, destination.ProductCount);
        }
    }
}
