using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ProductBasketService : IProductBasketService
    {
        private readonly IProductBasketRepository _productBasketRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public ProductBasketService(
            IProductBasketRepository productBasketRepository,
            IBasketRepository basketRepository,
            IMapper mapper)
        {
            _productBasketRepository = productBasketRepository;
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ProductBasketDto> GetById(int userId, int productId)
        {
            var basket = await GetBasketEntity(userId);

            var entity = await _productBasketRepository.GetById(productId, basket.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductBasket), productId);
            }

            return _mapper.Map<ProductBasketDto>(entity);
        }

        public async Task<int> AddProductInBasket(int userId, AddProductInBasketDto addProductInBasket)
        {
            var basket = await GetBasketEntity(userId);

            var entity = _mapper.Map<ProductBasket>(addProductInBasket);
            entity.BasketId = basket.Id;

            await _productBasketRepository.Create(entity);
            await _productBasketRepository.SaveChangesAsync();

            return entity.ProductId;
        }

        public async Task<IList<ProductBasketDto>> GetAllProductsInBasket(int userId)
        {
            var basket = await GetBasketEntity(userId);

            var entities = await _productBasketRepository.GetAllByBasketId(basket.Id);

            return _mapper.Map<IList<ProductBasketDto>>(entities);
        }

        public async Task UpdateProductInBasket(int userId, UpdateProductBasketDto updateProductBasket)
        {
            var basket = await GetBasketEntity(userId);

            var entity = await _productBasketRepository.GetById(updateProductBasket.ProductId, basket.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductBasket), updateProductBasket.ProductId);
            }

            entity.ProductCount = updateProductBasket.ProductCount;

            _productBasketRepository.Update(entity);

            await _productBasketRepository.SaveChangesAsync();
        }

        public async Task RemoveProductFromBasket(int userId, RemoveProductBasketDto removeProductBasket)
        {
            var basket = await GetBasketEntity(userId);

            var entity = await _productBasketRepository.GetById(removeProductBasket.ProductId, basket.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductBasket), removeProductBasket.ProductId);
            }

            _productBasketRepository.Delete(entity);

            await _productBasketRepository.SaveChangesAsync();
        }

        private async Task<Basket> GetBasketEntity(int userId)
        {
            var basket = await _basketRepository.GetByUserId(userId);

            if (basket == null)
            {
                throw new NotFoundException(nameof(Basket), userId);
            }

            return basket;
        }
    }
}
