using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Models.Order;
using JewelryStoreAPI.Presentations;
using System;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.OrderMapper
{
    public class OrderModelMapperTest
    {
        private readonly IMapper _mapper;

        public OrderModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_OrderDtoToOrderModel_SuccessfulMapping()
        {
            var source = new OrderDto()
            {
                OrderId = 1,
                OrderTime = DateTimeOffset.UtcNow,
                ProductCount = 1,
                TotalCost = 1
            };

            var destination = _mapper.Map<OrderModel>(source);

            Assert.Equal(source.OrderId, destination.OrderId);
            Assert.Equal(source.OrderTime, destination.OrderTime);
            Assert.Equal(source.ProductCount, destination.ProductCount);
            Assert.Equal(source.TotalCost, destination.TotalCost);
        }
    }
}
