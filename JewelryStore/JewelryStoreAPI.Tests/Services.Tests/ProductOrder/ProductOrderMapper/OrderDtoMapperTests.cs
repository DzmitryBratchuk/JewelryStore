using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductOrder.ProductOrderMapper
{
    using Entities = Domain.Entities;

    public class OrderDtoMapperTests
    {
        private readonly IMapper _mapper;

        public OrderDtoMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_Order_To_OrderDto()
        {
            var source = new Entities.Order()
            {
                Id = 1,
                OrderTime = DateTimeOffset.UtcNow,
                ProductOrders = new List<Entities.ProductOrder>()
                {
                    new Entities.ProductOrder
                    {
                        ProductCount = 1,
                        OrderId = 1,
                        ProductId = 1,
                        Product = new Entities.Product {Id=1, Cost=1 }
                    },
                    new Entities.ProductOrder
                    {
                        ProductCount = 2,
                        OrderId = 1,
                        ProductId = 2,
                        Product = new Entities.Product {Id=2, Cost=2 }
                    }
                }
            };

            var destination = _mapper.Map<OrderDto>(source);

            Assert.Equal(source.Id, destination.OrderId);
            Assert.Equal(source.OrderTime, destination.OrderTime);
            Assert.Equal(source.ProductOrders.Sum(x => x.ProductCount), destination.ProductCount);
            Assert.Equal(source.ProductOrders.Sum(x => x.ProductCount * x.Product.Cost), destination.TotalCost);
        }
    }
}
