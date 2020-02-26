using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket.ProductBasketMapper
{
    public class AddProductInBasketModelMapperTester
    {
        private readonly IMapper _mapper;

        public AddProductInBasketModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_AddProductInBasketModel_to_AddProductInBasketDto()
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

        [Fact]
        public void Should_not_have_error_AddProductInBasketModel_to_AddProductInBasketDto_DefaultProperty()
        {
            var source = new AddProductInBasketModel()
            {
                ProductId = default,
                ProductCount = default
            };

            var destination = _mapper.Map<AddProductInBasketDto>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCount);
        }
    }
}
