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

    public class ProductBasketServiceTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductBasketRepository> _mockProductBasketRepository;
        private readonly Mock<IBasketRepository> _mockBasketRepository;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public ProductBasketServiceTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockProductBasketRepository = new Mock<IProductBasketRepository>();
            _mockBasketRepository = new Mock<IBasketRepository>();

            int userId = 1;
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        }

        [Fact]
        public async Task Should_not_have_error_GetById()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var productBasket = new Entities.ProductBasket()
            {
                ProductId = productId,
                BasketId = basketId,
                ProductCount = 1,
                Product = new Entities.Product
                {
                    Id = productId,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productBasketService.GetById(productId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_have_error_GetById_BasketNotFoundException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.GetById(productId));
        }

        [Fact]
        public async Task Should_have_error_GetById_ProductBasketNotFoundException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            Entities.ProductBasket productBasket = null;

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.GetById(productId));
        }

        [Fact]
        public async Task Should_not_have_error_AddProductInBasket()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var productBasket = new Entities.ProductBasket()
            {
                ProductId = productId,
                BasketId = basketId,
                ProductCount = 1,
                Product = new Entities.Product
                {
                    Id = productId,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            var addProductInBasketDto = new AddProductInBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.Create(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync());
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productBasketService.AddProductInBasket(addProductInBasketDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_have_error_AddProductInBasket_NotFoundException()
        {
            int userId = 1;
            int productId = 1;

            Entities.Basket basket = null;

            var addProductInBasketDto = new AddProductInBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.AddProductInBasket(addProductInBasketDto));
        }

        [Fact]
        public async Task Should_have_error_AddProductInBasket_OrmException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;


            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var addProductInBasketDto = new AddProductInBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.Create(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productBasketService.AddProductInBasket(addProductInBasketDto));
        }

        [Fact]
        public async Task Should_not_have_error_GetAllProductsInBasket()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            IList<Entities.ProductBasket> productBaskets = new List<Entities.ProductBasket>()
            {
                new Entities.ProductBasket()
                {
                    ProductId = productId,
                    BasketId = basketId,
                    ProductCount = 1,
                    Product = new Entities.Product
                    {
                        Id = productId,
                        Name = "Test name",
                        Cost = 1,
                        BrandId = 1,
                        Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                        CountryId = 1,
                        Country = new Entities.Country { Id = 1, Name = "Test country" }
                    }
                }
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetAllByBasketId(basket.Id)).Returns(Task.FromResult(productBaskets));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            var result = await productBasketService.GetAllProductsInBasket();

            Assert.Equal(productBaskets.Count, result.Count);
        }

        [Fact]
        public async Task Should_have_error_GetAllProductsInBasket_NotFoundException()
        {
            int userId = 1;

            Entities.Basket basket = null;

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.GetAllProductsInBasket());
        }

        [Fact]
        public async Task Should_not_have_error_UpdateProductInBasket()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var productBasket = new Entities.ProductBasket()
            {
                ProductId = productId,
                BasketId = basketId,
                ProductCount = 1,
                Product = new Entities.Product
                {
                    Id = productId,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            var updateProductBasketDto = new UpdateProductBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));
            _mockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync());

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await productBasketService.UpdateProductInBasket(updateProductBasketDto);
        }

        [Fact]
        public async Task Should_have_error_UpdateProductInBasket_BasketNotFoundException()
        {
            int userId = 1;
            int productId = 1;

            Entities.Basket basket = null;

            var updateProductBasketDto = new UpdateProductBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.UpdateProductInBasket(updateProductBasketDto));
        }

        [Fact]
        public async Task Should_have_error_UpdateProductInBasket_ProductBasketNotFoundException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            Entities.ProductBasket productBasket = null;

            var updateProductBasketDto = new UpdateProductBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.UpdateProductInBasket(updateProductBasketDto));
        }

        [Fact]
        public async Task Should_have_error_UpdateProductInBasket_OrmException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var productBasket = new Entities.ProductBasket()
            {
                ProductId = productId,
                BasketId = basketId,
                ProductCount = 1,
                Product = new Entities.Product
                {
                    Id = productId,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            var updateProductBasketDto = new UpdateProductBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));
            _mockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productBasketService.UpdateProductInBasket(updateProductBasketDto));
        }

        [Fact]
        public async Task Should_not_have_error_RemoveProductFromBasket()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var productBasket = new Entities.ProductBasket()
            {
                ProductId = productId,
                BasketId = basketId,
                ProductCount = 1,
                Product = new Entities.Product
                {
                    Id = productId,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));
            _mockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync());

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await productBasketService.RemoveProductFromBasket(productId);
        }

        [Fact]
        public async Task Should_have_error_RemoveProductFromBasket_BasketNotFoundException()
        {
            int userId = 1;
            int productId = 1;

            Entities.Basket basket = null;

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.RemoveProductFromBasket(productId));
        }

        [Fact]
        public async Task Should_have_error_RemoveProductFromBasket_ProductBasketNotFoundException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            Entities.ProductBasket productBasket = null;

            var updateProductBasketDto = new UpdateProductBasketDto()
            {
                ProductId = productId,
                ProductCount = 1
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => productBasketService.RemoveProductFromBasket(productId));
        }

        [Fact]
        public async Task Should_have_error_RemoveProductFromBasket_OrmException()
        {
            int userId = 1;
            int productId = 1;
            int basketId = 1;

            var basket = new Entities.Basket()
            {
                Id = basketId,
                UserId = userId,
            };

            var productBasket = new Entities.ProductBasket()
            {
                ProductId = productId,
                BasketId = basketId,
                ProductCount = 1,
                Product = new Entities.Product
                {
                    Id = productId,
                    Name = "Test name",
                    Cost = 1,
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" }
                }
            };

            _mockBasketRepository.Setup(p => p.GetByUserId(userId)).Returns(Task.FromResult(basket));
            _mockProductBasketRepository.Setup(p => p.GetById(productId, basket.Id)).Returns(Task.FromResult(productBasket));
            _mockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _mockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var productBasketService = new ProductBasketService(_mockProductBasketRepository.Object, _mockBasketRepository.Object, _mapper, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => productBasketService.RemoveProductFromBasket(productId));
        }
    }
}
