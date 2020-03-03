using JewelryStoreAPI.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket
{
    public class ProductBasketServiceTest : IClassFixture<ProductBasketServiceFixture>
    {
        private readonly ProductBasketServiceFixture _fixture;

        public ProductBasketServiceTest(ProductBasketServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetByIdAsync_ProductIdExist_NotEmptyResult()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets[0]));

            var result = await _fixture.ProductBasketService.GetByIdAsync(_fixture.ProductId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_BasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.Basket basket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(basket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.GetByIdAsync(_fixture.ProductId));
        }

        [Fact]
        public async Task GetByIdAsync_ProductBasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.ProductBasket productBasket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(productBasket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.GetByIdAsync(_fixture.ProductId));
        }

        [Fact]
        public async Task AddProductInBasketAsync_BasketEntityExist_NotEmptyResult()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.ProductBasket>()));
            _fixture.MockProductBasketRepository.Setup(p => p.SaveChangesAsync());
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets[0]));

            var result = await _fixture.ProductBasketService.AddProductInBasketAsync(_fixture.AddProductInBasketDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddProductInBasketAsync_BasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.Basket basket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(basket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.AddProductInBasketAsync(_fixture.AddProductInBasketDto));
        }

        [Fact]
        public async Task AddProductInBasketAsync_BasketEntityExist_OrmExceptionThrown()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.ProductBasket>()));
            _fixture.MockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            await Assert.ThrowsAsync<DbUpdateException>(() => _fixture.ProductBasketService.AddProductInBasketAsync(_fixture.AddProductInBasketDto));
        }

        [Fact]
        public async Task GetAllProductsInBasketAsync_BasketEntityExist_NotEmptyResult()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetAllByBasketIdAsync(_fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets));

            var result = await _fixture.ProductBasketService.GetAllProductsInBasketAsync();

            Assert.Equal(_fixture.ProductBaskets.Count, result.Count);
        }

        [Fact]
        public async Task GetAllProductsInBasketAsync_BasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.Basket basket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(basket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.GetAllProductsInBasketAsync());
        }

        [Fact]
        public async Task UpdateProductInBasketAsync_ValidProductBasketEntity_SuccessfulUpdate()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets[0]));
            _fixture.MockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _fixture.MockProductBasketRepository.Setup(p => p.SaveChangesAsync());

            await _fixture.ProductBasketService.UpdateProductInBasketAsync(_fixture.UpdateProductBasketDto);
        }

        [Fact]
        public async Task UpdateProductInBasketAsync_BasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.Basket basket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(basket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.UpdateProductInBasketAsync(_fixture.UpdateProductBasketDto));
        }

        [Fact]
        public async Task UpdateProductInBasketAsync_ProductBasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.ProductBasket productBasket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(productBasket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.UpdateProductInBasketAsync(_fixture.UpdateProductBasketDto));
        }

        [Fact]
        public async Task UpdateProductInBasketAsync_ValidProductBasketEntity_OrmExceptionThrown()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets[0]));
            _fixture.MockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _fixture.MockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            await Assert.ThrowsAsync<DbUpdateException>(() => _fixture.ProductBasketService.UpdateProductInBasketAsync(_fixture.UpdateProductBasketDto));
        }

        [Fact]
        public async Task RemoveProductFromBasketAsync_ProductIdExist_SuccessfulDeletion()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets[0]));
            _fixture.MockProductBasketRepository.Setup(p => p.Delete(It.IsAny<Entities.ProductBasket>()));
            _fixture.MockProductBasketRepository.Setup(p => p.SaveChangesAsync());

            await _fixture.ProductBasketService.RemoveProductFromBasketAsync(_fixture.ProductId);
        }

        [Fact]
        public async Task RemoveProductFromBasketAsync_BasketEntityDoesNotExist_ExceptionThrown()
        {
            Entities.Basket basket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(basket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.RemoveProductFromBasketAsync(_fixture.ProductId));
        }

        [Fact]
        public async Task RemoveProductFromBasketAsync_ProductIdDoesNotExist_ExceptionThrown()
        {
            Entities.ProductBasket productBasket = null;

            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(productBasket));

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.ProductBasketService.RemoveProductFromBasketAsync(_fixture.ProductId));
        }

        [Fact]
        public async Task RemoveProductFromBasketAsync_ValidProductBasketEntity_OrmExceptionThrown()
        {
            _fixture.MockBasketRepository.Setup(p => p.GetByUserIdAsync(_fixture.UserId)).Returns(Task.FromResult(_fixture.Basket));
            _fixture.MockProductBasketRepository.Setup(p => p.GetByIdAsync(_fixture.ProductId, _fixture.Basket.Id)).Returns(Task.FromResult(_fixture.ProductBaskets[0]));
            _fixture.MockProductBasketRepository.Setup(p => p.Update(It.IsAny<Entities.ProductBasket>()));
            _fixture.MockProductBasketRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            await Assert.ThrowsAsync<DbUpdateException>(() => _fixture.ProductBasketService.RemoveProductFromBasketAsync(_fixture.ProductId));
        }
    }
}
