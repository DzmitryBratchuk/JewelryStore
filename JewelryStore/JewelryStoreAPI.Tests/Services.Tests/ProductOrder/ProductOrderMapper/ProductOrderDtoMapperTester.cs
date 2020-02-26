using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductOrder.ProductOrderMapper
{
    using Entities = Domain.Entities;

    public class ProductOrderDtoMapperTester
    {
        private readonly IMapper _mapper;

        public ProductOrderDtoMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ProductOrder_to_ProductOrderDto()
        {
            var source = new Entities.ProductOrder()
            {
                OrderId = 1,
                ProductId = 1,
                ProductCount = 1,
                Order = new Entities.Order { Id = 1 },
                Product = new Entities.Product
                {
                    Id = 1,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            var destination = _mapper.Map<ProductOrderDto>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCount);
            Assert.Equal(source.Product.Name, destination.ProductName);
            Assert.Equal(source.Product.Brand.Name, destination.ProductBrand);
            Assert.Equal(source.Product.Country.Name, destination.ProductCountry);
            Assert.Equal(source.Product.Cost, destination.ProductCost);
        }

        [Fact]
        public void Should_not_have_error_ProductOrder_to_ProductOrderDto_DefaultProperty()
        {
            var source = new Entities.ProductOrder()
            {
                OrderId = default,
                ProductId = default,
                ProductCount = default,
                Order = default,
                Product = default
            };

            var destination = _mapper.Map<ProductOrderDto>(source);

            Assert.Equal(source.ProductId, destination.ProductId);
            Assert.Equal(source.ProductCount, destination.ProductCount);
            Assert.Null(destination.ProductName);
            Assert.Null(destination.ProductBrand);
            Assert.Null(destination.ProductCountry);
            Assert.Equal(default, destination.ProductCost);
        }
    }
}
