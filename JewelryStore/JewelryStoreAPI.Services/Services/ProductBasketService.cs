using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ProductBasketService : IProductBasketService
    {
        private readonly IProductBasketRepository _productBasketRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public ProductBasketService(
            IProductBasketRepository productBasketRepository,
            IBasketRepository basketRepository,
            IMapper mapper,
            ClaimsPrincipal claimsPrincipal)
        {
            _productBasketRepository = productBasketRepository;
            _basketRepository = basketRepository;
            _mapper = mapper;
            _claimsPrincipal = claimsPrincipal;
        }

        public async Task<ProductBasketDto> GetByIdAsync(int productId)
        {
            var basket = await GetBasketEntity();

            var entity = await _productBasketRepository.GetByIdAsync(productId, basket.Id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(ProductBasket), productId, ErrorCode.NotFound);
            }

            return _mapper.Map<ProductBasketDto>(entity);
        }

        public async Task<ProductBasketDto> AddProductInBasketAsync(AddProductInBasketDto addProductInBasket)
        {
            var basket = await GetBasketEntity();

            var entity = _mapper.Map<ProductBasket>(addProductInBasket);
            entity.BasketId = basket.Id;

            await _productBasketRepository.CreateAsync(entity);
            await _productBasketRepository.SaveChangesAsync();

            var addedEntity = await _productBasketRepository.GetByIdAsync(entity.ProductId, basket.Id);

            return _mapper.Map<ProductBasketDto>(addedEntity);
        }

        public async Task<IList<ProductBasketDto>> GetAllProductsInBasketAsync()
        {
            var basket = await GetBasketEntity();

            var entities = await _productBasketRepository.GetAllByBasketIdAsync(basket.Id);

            return _mapper.Map<IList<ProductBasketDto>>(entities);
        }

        public async Task UpdateProductInBasketAsync(UpdateProductBasketDto updateProductBasket)
        {
            var basket = await GetBasketEntity();

            var entity = await _productBasketRepository.GetByIdAsync(updateProductBasket.ProductId, basket.Id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(ProductBasket), updateProductBasket.ProductId, ErrorCode.NotFound);
            }

            entity.ProductCount = updateProductBasket.ProductCount;

            _productBasketRepository.Update(entity);

            await _productBasketRepository.SaveChangesAsync();
        }

        public async Task RemoveProductFromBasketAsync(int productId)
        {
            var basket = await GetBasketEntity();

            var entity = await _productBasketRepository.GetByIdAsync(productId, basket.Id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(ProductBasket), productId, ErrorCode.NotFound);
            }

            _productBasketRepository.Delete(entity);

            await _productBasketRepository.SaveChangesAsync();
        }

        private async Task<Basket> GetBasketEntity()
        {
            var userId = GetUserId();

            var basket = await _basketRepository.GetByUserIdAsync(userId);

            if (basket == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(Basket), userId, ErrorCode.NotFound);
            }

            return basket;
        }

        private int GetUserId()
        {
            return Convert.ToInt32(_claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
