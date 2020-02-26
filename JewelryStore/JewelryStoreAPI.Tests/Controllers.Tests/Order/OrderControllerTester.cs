using AutoMapper;
using JewelryStoreAPI.Controllers;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Order;
using JewelryStoreAPI.Models.ProductOrder;
using JewelryStoreAPI.Presentations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order
{
    public class OrderControllerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductOrderService> _mockProductOrderService;

        public OrderControllerTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
            _mockProductOrderService = new Mock<IProductOrderService>();
        }

        [Fact]
        public async Task Should_not_have_error_GetAllUserOrders()
        {
            IList<OrderDto> orderDto = new List<OrderDto>()
            {
                new OrderDto
                {
                    OrderId = 1,
                    OrderTime = DateTimeOffset.UtcNow,
                    ProductCount = 1,
                    TotalCost = 1
                }
            };

            _mockProductOrderService.Setup(p => p.GetAllUserOrders()).Returns(Task.FromResult(orderDto));

            var orderController = new OrderController(_mockProductOrderService.Object, _mapper);

            var result = await orderController.GetAllUserOrders();

            Assert.Equal(orderDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllProductsInOrder()
        {
            int orderId = 1;

            IList<ProductOrderDto> productOrderDto = new List<ProductOrderDto>()
            {
                new ProductOrderDto
                {
                    ProductId = 1,
                    ProductName = "Test name",
                    ProductBrand = "Test brand",
                    ProductCountry = "Test country",
                    ProductCount = 1,
                    ProductCost = 100
                }
            };

            _mockProductOrderService.Setup(p => p.GetAllProductsInOrder(It.IsAny<int>())).Returns(Task.FromResult(productOrderDto));

            var orderController = new OrderController(_mockProductOrderService.Object, _mapper);

            var result = await orderController.GetAllProductsInOrder(orderId);

            Assert.Equal(productOrderDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_Create()
        {
            var createOrderModel = new CreateOrderModel()
            {
                ProductIds = new List<int>() { 1, 2, 3 }
            };

            IList<ProductOrderDto> productOrderDto = new List<ProductOrderDto>()
            {
                new ProductOrderDto
                {
                    ProductId = 1,
                    ProductName = "Test name",
                    ProductBrand = "Test brand",
                    ProductCountry = "Test country",
                    ProductCount = 1,
                    ProductCost = 100
                }
            };

            _mockProductOrderService.Setup(p => p.CreateOrder(It.IsAny<CreateOrderDto>())).Returns(Task.FromResult(productOrderDto));

            var orderController = new OrderController(_mockProductOrderService.Object, _mapper);

            var result = await orderController.CreateOrder(createOrderModel);

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            var createdData = result as CreatedAtActionResult;

            Assert.IsAssignableFrom<IList<ProductOrderModel>>(createdData.Value);
            var productOrderModel = createdData.Value as IList<ProductOrderModel>;

            Assert.NotEmpty(productOrderModel);
        }
    }
}
