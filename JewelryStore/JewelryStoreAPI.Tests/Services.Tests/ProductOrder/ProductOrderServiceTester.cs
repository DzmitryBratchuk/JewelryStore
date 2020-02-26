using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Exceptions;
using JewelryStoreAPI.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductOrder
{
    using Entities = Domain.Entities;

    public class ProductOrderServiceTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductOrderRepository> _mockProductOrderRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductBasketRepository> _mockProductBasketRepository;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public ProductOrderServiceTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockProductOrderRepository = new Mock<IProductOrderRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductBasketRepository = new Mock<IProductBasketRepository>();

            int userId = 1;
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllProductsInOrder()
        {
            int userId = 1;
            int orderId = 1;

            IList<Entities.ProductOrder> entities = new List<Entities.ProductOrder>()
            {
                new Entities.ProductOrder()
                {
                    OrderId = orderId,
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
                }
            };

            _mockProductOrderRepository.Setup(p => p.GetAllByOrderId(userId, orderId)).Returns(Task.FromResult(entities));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productOrderService.GetAllProductsInOrder(orderId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllUserOrders()
        {
            int userId = 1;
            int orderId = 1;

            IList<Entities.Order> entities = new List<Entities.Order>()
            {
                new Entities.Order()
                {
                    Id = orderId,
                    OrderTime = DateTimeOffset.UtcNow,
                    ProductOrders = new List<Entities.ProductOrder>()
                    {
                        new Entities.ProductOrder
                        {
                            ProductCount = 1,
                            OrderId = orderId,
                            ProductId = 1,
                            Product = new Entities.Product {Id=1, Cost=1 }
                        },
                        new Entities.ProductOrder
                        {
                            ProductCount = 2,
                            OrderId = orderId,
                            ProductId = 2,
                            Product = new Entities.Product {Id=2, Cost=2 }
                        }
                    }
                }
            };

            _mockOrderRepository.Setup(p => p.GetAllByUserId(userId)).Returns(Task.FromResult(entities));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productOrderService.GetAllUserOrders();

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_CreateOrder()
        {
            int userId = 1;
            int orderId = 1;

            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = orderId,
                ProductIds = new List<int> { 1, 2, 2, 3 }
            };

            IList<Entities.ProductBasket> productsInBasket = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=2 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserId(userId)).Returns(Task.FromResult(productsInBasket));
            _mockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _mockOrderRepository.Setup(p => p.Create(It.IsAny<Entities.Order>()));
            _mockOrderRepository.Setup(p => p.SaveChangesAsync());

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productOrderService.CreateOrder(createOrderDto);

            Assert.Equal(createOrderDto.ProductIds.Distinct().Count(), result.Count);
        }

        [Fact]
        public async Task Should_have_error_CreateOrder_OrmException()
        {
            int userId = 1;
            int orderId = 1;

            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = orderId,
                ProductIds = new List<int> { 1, 2, 2, 3 }
            };

            IList<Entities.ProductBasket> productsInBasket = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=2 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserId(userId)).Returns(Task.FromResult(productsInBasket));
            _mockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _mockOrderRepository.Setup(p => p.Create(It.IsAny<Entities.Order>()));
            _mockOrderRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productOrderService.CreateOrder(createOrderDto));
        }

        [Fact]
        public async Task Should_have_error_CreateOrder_BasketConflict()
        {
            int userId = 1;
            int orderId = 1;

            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = orderId,
                ProductIds = new List<int> { 1, 2, 2, 2, 3 }
            };

            IList<Entities.ProductBasket> productsInBasket = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=2 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserId(userId)).Returns(Task.FromResult(productsInBasket));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productOrderService.CreateOrder(createOrderDto));
        }

        [Fact]
        public async Task Should_have_error_CreateOrder_StoreConflict()
        {
            int userId = 1;
            int orderId = 1;

            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = orderId,
                ProductIds = new List<int> { 1, 2, 2, 3 }
            };

            IList<Entities.ProductBasket> productsInBasket = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserId(userId)).Returns(Task.FromResult(productsInBasket));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productOrderService.CreateOrder(createOrderDto));
        }

        [Fact]
        public async Task Should_have_error_CreateOrder_NotFoundProductInBasket()
        {
            int userId = 1;
            int orderId = 1;

            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = orderId,
                ProductIds = new List<int> { 1, 2, 2, 4 }
            };

            IList<Entities.ProductBasket> productsInBasket = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=2 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserId(userId)).Returns(Task.FromResult(productsInBasket));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productOrderService.CreateOrder(createOrderDto));
        }
    }
}
