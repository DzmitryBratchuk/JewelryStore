using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ProductBasketService : IProductBasketService
    {
        private readonly IProductBasketRepository _productBasketRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly string _username;

        public ProductBasketService(IProductBasketRepository productBasketRepository,
            IHttpContextAccessor httpContextAccessor,
            IBasketRepository basketRepository,
            IMapper mapper)
        {
            _productBasketRepository = productBasketRepository;
            _httpContextAccessor = httpContextAccessor;
            _basketRepository = basketRepository;
            _mapper = mapper;

            _username = _httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<ProductBasketDto> GetById(int productId)
        {
            var basket = await _basketRepository.GetByUserLogin(_username);

            if (basket == null)
            {
                throw new NotFoundException(nameof(Basket), _username);
            }

            var entity = await _productBasketRepository.GetById(productId, basket.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductBasket), productId);
            }

            return _mapper.Map<ProductBasketDto>(entity);
        }

        public async Task AddProductInBasket(AddProductInBasketDto addProductInBasket)
        {
            var basket = await _basketRepository.GetByUserLogin(_username);

            if (basket == null)
            {
                throw new NotFoundException(nameof(Basket), _username);
            }

            var entity = _mapper.Map<ProductBasket>(addProductInBasket);
            entity.BasketId = basket.Id;

            await _productBasketRepository.Create(entity);
            await _productBasketRepository.SaveChangesAsync();

            addProductInBasket.ProductId = entity.ProductId;
        }

        public async Task<IList<ProductBasketDto>> GetAllProductsInBasket()
        {
            var basket = await _basketRepository.GetByUserLogin(_username);

            if (basket == null)
            {
                throw new NotFoundException(nameof(Basket), _username);
            }

            var entities = await _productBasketRepository.GetAllByBasketId(basket.Id);

            return _mapper.Map<IList<ProductBasketDto>>(entities);
        }

        public async Task UpdateProductInBasket(int productId, UpdateProductBasketDto updateProductBasket)
        {
            var basket = await _basketRepository.GetByUserLogin(_username);

            if (basket == null)
            {
                throw new NotFoundException(nameof(Basket), _username);
            }

            var entity = await _productBasketRepository.GetById(productId, basket.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductBasket), productId);
            }

            entity.ProductCount = updateProductBasket.ProductCount;

            _productBasketRepository.Update(entity);

            await _productBasketRepository.SaveChangesAsync();
        }

        public async Task RemoveProductFromBasket(RemoveProductBasketDto removeProductBasket)
        {
            var basket = await _basketRepository.GetByUserLogin(_username);

            if (basket == null)
            {
                throw new NotFoundException(nameof(Basket), _username);
            }

            var entity = await _productBasketRepository.GetById(removeProductBasket.ProductId, basket.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductBasket), removeProductBasket.ProductId);
            }

            _productBasketRepository.Delete(entity);

            await _productBasketRepository.SaveChangesAsync();
        }
    }
}
