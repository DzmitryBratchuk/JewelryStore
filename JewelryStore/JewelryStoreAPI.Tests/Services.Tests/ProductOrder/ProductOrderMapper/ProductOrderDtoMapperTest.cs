﻿using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductOrder.ProductOrderMapper
{
    public class ProductOrderDtoMapperTest
    {
        private readonly IMapper _mapper;

        public ProductOrderDtoMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_ProductOrderToProductOrderDto_SuccessfulMapping()
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
