using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class UpdateProductBasketModelMapperTests
    {
        private readonly IMapper _mapper;

        public UpdateProductBasketModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_UpdateProductBasketModel_To_UpdateProductBasketDto()
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
