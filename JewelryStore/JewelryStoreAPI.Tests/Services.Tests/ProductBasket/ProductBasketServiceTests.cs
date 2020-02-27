using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Exceptions;
using JewelryStoreAPI.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket
{
    using Entities = Domain.Entities;

    public class ProductBasketServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductBasketRepository> _mockProductBasketRepository;
        private readonly Mock<IBasketRepository> _mockBasketRepository;
        private readonly ClaimsPrincipal _claimsPrincipal;

        private IList<Entities.ProductBasket> _productBaskets;
        private Entities.Basket _basket;
        private AddProductInBasketDto _addProductInBasketDto;
        private UpdateProductBasketDto _updateProductBasketDto;
        private int _userId;
        private int _productId;

        public ProductBasketServiceTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockProductBasketRepository = new Mock<IProductBasketRepository>();
            _mockBasketRepository = new Mock<IBasketRepository>();

            _userId = 1;
            _productId = 1;


            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, _userId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            Initialization();
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetById()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(_productBaskets[0]));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productBasketService.GetByIdAsync(_productId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Have_Error_GetById_BasketNotFoundException()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.GetByIdAsync(_productId));
        }

        [Fact]
        public async Task Should_Have_Error_GetById_ProductBasketNotFoundException()
        {
            Entities.ProductBasket productBasket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.GetByIdAsync(_productId));
        }

        [Fact]
        public async Task Should_Not_Have_Error_AddProductInBasket()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync());
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(_productBaskets[0]));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productBasketService.AddProductInBasketAsync(_addProductInBasketDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Have_Error_AddProductInBasket_NotFoundException()
        {
            Entities.Basket basket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.AddProductInBasketAsync(_addProductInBasketDto));
        }

        [Fact]
        public async Task Should_Have_Error_AddProductInBasket_OrmException()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productBasketService.AddProductInBasketAsync(_addProductInBasketDto));
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetAllProductsInBasket()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetAllByBasketIdAsync(_basket.Id)).Returns(Task.FromResult(_productBaskets));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productBasketService.GetAllProductsInBasketAsync();

            Assert.Equal(_productBaskets.Count, result.Count);
        }

        [Fact]
        public async Task Should_Have_Error_GetAllProductsInBasket_NotFoundException()
        {
            Entities.Basket basket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.GetAllProductsInBasketAsync());
        }

        [Fact]
        public async Task Should_Not_Have_Error_UpdateProductInBasket()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(_productBaskets[0]));
            _mockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync());

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await productBasketService.UpdateProductInBasketAsync(_updateProductBasketDto);
        }

        [Fact]
        public async Task Should_Have_Error_UpdateProductInBasket_BasketNotFoundException()
        {
            Entities.Basket basket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.UpdateProductInBasketAsync(_updateProductBasketDto));
        }

        [Fact]
        public async Task Should_Have_Error_UpdateProductInBasket_ProductBasketNotFoundException()
        {
            Entities.ProductBasket productBasket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.UpdateProductInBasketAsync(_updateProductBasketDto));
        }

        [Fact]
        public async Task Should_Have_Error_UpdateProductInBasket_OrmException()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(_productBaskets[0]));
            _mockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productBasketService.UpdateProductInBasketAsync(_updateProductBasketDto));
        }

        [Fact]
        public async Task Should_Not_Have_Error_RemoveProductFromBasket()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(_productBaskets[0]));
            _mockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync());

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await productBasketService.RemoveProductFromBasketAsync(_productId);
        }

        [Fact]
        public async Task Should_Have_Error_RemoveProductFromBasket_BasketNotFoundException()
        {
            Entities.Basket basket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.RemoveProductFromBasketAsync(_productId));
        }

        [Fact]
        public async Task Should_Have_Error_RemoveProductFromBasket_ProductBasketNotFoundException()
        {
            Entities.ProductBasket productBasket = null;

            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.RemoveProductFromBasketAsync(_productId));
        }

        [Fact]
        public async Task Should_Have_Error_RemoveProductFromBasket_OrmException()
        {
            _mockBasketRepository.Setup(p => p.GetByUserIdAsync(_userId)).Returns(Task.FromResult(_basket));
            _mockProductBasketRepository.Setup(p => p.GetByIdAsync(_productId, _basket.Id)).Returns(Task.FromResult(_productBaskets[0]));
            _mockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productBasketService.RemoveProductFromBasketAsync(_productId));
        }

        private void Initialization()
        {
            _productBaskets = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket()
                {
                    ProductId = 1,
                    BasketId = 1,
                    ProductCount = 1,
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

            _basket = new Entities.Basket()
            {
                Id = 1,
                UserId = 1,
            };

            _addProductInBasketDto = new AddProductInBasketDto()
            {
                ProductId = 1,
                ProductCount = 1
            };

            _updateProductBasketDto = new UpdateProductBasketDto()
            {
                ProductId = 1,
                ProductCount = 1
            };
        }
    }
}
