using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class UpdateProductBasketModelMapperTester
    {
        private readonly IMapper _mapper;

        public UpdateProductBasketModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_UpdateProductBasketModel_to_UpdateProductBasketDto()
        {
            var source = new UpdateProductBasketModel()
            {
                ProductCount = 1
            };

            var destination = _mapper.Map<UpdateProductBasketDto>(source);

            Assert.Equal(source.ProductCount, destination.ProductCount);
        }

        [Fact]
        public void Should_not_have_error_UpdateProductBasketModel_to_UpdateProductBasketDto_DefaultProperty()
        {
            var source = new UpdateProductBasketModel()
            {
                ProductCount = default
            };

            var destination = _mapper.Map<UpdateProductBasketDto>(source);

            Assert.Equal(source.ProductCount, destination.ProductCount);
        }
    }
}
