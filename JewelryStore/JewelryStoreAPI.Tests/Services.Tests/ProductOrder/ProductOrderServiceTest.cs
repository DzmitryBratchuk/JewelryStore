using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Exceptions;
using JewelryStoreAPI.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductOrder
{
    public class ProductOrderServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductOrderRepository> _mockProductOrderRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductBasketRepository> _mockProductBasketRepository;
        private readonly ClaimsPrincipal _claimsPrincipal;

        private IList<Entities.ProductBasket> _productsInBasket;
        private readonly int _userId;
        private readonly int _orderId;

        public ProductOrderServiceTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockProductOrderRepository = new Mock<IProductOrderRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductBasketRepository = new Mock<IProductBasketRepository>();

            _userId = 1;
            _orderId = 1;

            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, _userId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            Initialization();
        }

        [Fact]
        public async Task GetAllProductsInOrderAsync_NotEmptyResult()
        {
            IList<Entities.ProductOrder> entities = new List<Entities.ProductOrder>()
            {
                new Entities.ProductOrder()
                {
                    OrderId = _orderId,
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

            _mockProductOrderRepository.Setup(p => p.GetAllByOrderIdAsync(_userId, _orderId)).Returns(Task.FromResult(entities));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productOrderService.GetAllProductsInOrderAsync(_orderId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task GetAllUserOrdersAsync_NotEmptyResult()
        {
            IList<Entities.Order> entities = new List<Entities.Order>()
            {
                new Entities.Order()
                {
                    Id = _orderId,
                    OrderTime = DateTimeOffset.UtcNow,
                    ProductOrders = new List<Entities.ProductOrder>()
                    {
                        new Entities.ProductOrder
                        {
                            ProductCount = 1,
                            OrderId = _orderId,
                            ProductId = 1,
                            Product = new Entities.Product {Id=1, Cost=1 }
                        },
                        new Entities.ProductOrder
                        {
                            ProductCount = 2,
                            OrderId = _orderId,
                            ProductId = 2,
                            Product = new Entities.Product {Id=2, Cost=2 }
                        }
                    }
                }
            };

            _mockOrderRepository.Setup(p => p.GetAllByUserIdAsync(_userId)).Returns(Task.FromResult(entities));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productOrderService.GetAllUserOrdersAsync();

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task CreateOrderAsync_ValidOrderEntity_NotEmptyResult()
        {
            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = _orderId,
                ProductIds = new List<int> { 1, 2, 2, 3 }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserIdAsync(_userId)).Returns(Task.FromResult(_productsInBasket));
            _mockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _mockOrderRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.Order>()));
            _mockOrderRepository.Setup(p => p.SaveChangesAsync());

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productOrderService.CreateOrderAsync(createOrderDto);

            Assert.Equal(createOrderDto.ProductIds.Distinct().Count(), result.Count);
        }

        [Fact]
        public async Task CreateOrderAsync_ValidOrderEntity_OrmExceptionThrown()
        {
            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = _orderId,
                ProductIds = new List<int> { 1, 2, 2, 3 }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserIdAsync(_userId)).Returns(Task.FromResult(_productsInBasket));
            _mockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _mockOrderRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.Order>()));
            _mockOrderRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<DbUpdateException>(() => productOrderService.CreateOrderAsync(createOrderDto));
        }

        [Fact]
        public async Task CreateOrderAsync_BasketConflict_ExceptionThrown()
        {
            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = _orderId,
                ProductIds = new List<int> { 1, 2, 2, 2, 3 }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserIdAsync(_userId)).Returns(Task.FromResult(_productsInBasket));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productOrderService.CreateOrderAsync(createOrderDto));
        }

        [Fact]
        public async Task CreateOrderAsync_StoreConflict_ExceptionThrown()
        {
            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = _orderId,
                ProductIds = new List<int> { 1, 2, 2, 3 }
            };

            IList<Entities.ProductBasket> productsInBasket = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserIdAsync(_userId)).Returns(Task.FromResult(productsInBasket));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productOrderService.CreateOrderAsync(createOrderDto));
        }

        [Fact]
        public async Task CreateOrderAsync_ProductInBasketDoesNotExist_ExceptionThrown()
        {
            CreateOrderDto createOrderDto = new CreateOrderDto()
            {
                Id = _orderId,
                ProductIds = new List<int> { 1, 2, 2, 4 }
            };

            _mockProductBasketRepository.Setup(p => p.GetAllByUserIdAsync(_userId)).Returns(Task.FromResult(_productsInBasket));

            var productOrderService = new ProductOrderService(_mockProductOrderRepository.Object, _mockOrderRepository.Object, _mockProductBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productOrderService.CreateOrderAsync(createOrderDto));
        }

        private void Initialization()
        {
            _productsInBasket = new List<Entities.ProductBasket>
            {
                new Entities.ProductBasket() { ProductId = 1, ProductCount = 1, Product = new Entities.Product { Amount=1 } },
                new Entities.ProductBasket() { ProductId = 2, ProductCount = 2, Product = new Entities.Product { Amount=2 } },
                new Entities.ProductBasket() { ProductId = 3, ProductCount = 3, Product = new Entities.Product { Amount=3 } }
            };
        }
    }
}
