using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductOrder.ProductOrderMapper
{
    using Entities = Domain.Entities;

    public class ProductOrderDtoMapperTests
    {
        private readonly IMapper _mapper;

        public ProductOrderDtoMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_ProductOrder_To_ProductOrderDto()
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
    }
}
