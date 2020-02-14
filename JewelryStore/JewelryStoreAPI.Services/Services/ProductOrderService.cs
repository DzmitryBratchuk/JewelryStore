﻿using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductBasketRepository _productBasketRepository;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public ProductOrderService(
            IProductOrderRepository productOrderRepository,
            IOrderRepository orderRepository,
            IProductBasketRepository productBasketRepository,
            IMapper mapper,
            ClaimsPrincipal claimsPrincipal)
        {
            _productOrderRepository = productOrderRepository;
            _orderRepository = orderRepository;
            _productBasketRepository = productBasketRepository;
            _mapper = mapper;
            _claimsPrincipal = claimsPrincipal;
        }

        public async Task<IList<ProductOrderDto>> GetAllProductsInOrder(int orderId)
        {
            var userId = GetUserId();

            var entities = await _productOrderRepository.GetAllByOrderId(userId, orderId);

            return _mapper.Map<IList<ProductOrderDto>>(entities);
        }

        public async Task<IList<OrderDto>> GetAllUserOrders()
        {
            var userId = GetUserId();

            var orders = await _orderRepository.GetAllByUserId(userId);

            return _mapper.Map<IList<OrderDto>>(orders);
        }

        public async Task<IList<ProductOrderDto>> CreateOrder(CreateOrderDto createOrder)
        {
            var productsInBasket = (await _productBasketRepository.GetAllByUserId(GetUserId())).ToList();

            bool isValid = IsValidProductsInBasket(productsInBasket, createOrder);

            if (!isValid)
            {
                throw new NotFoundException($"Not enough products in store.");
            }

            var productsInOrder = AddProductsInOrder(createOrder);

            var entity = new Order()
            {
                ProductOrders = productsInOrder,
                OrderTime = DateTimeOffset.UtcNow,
                UserId = GetUserId(),
            };

            ReduceProductsInBasketAndStore(productsInBasket, productsInOrder);

            await _orderRepository.Create(entity);
            await _orderRepository.SaveChangesAsync();

            return _mapper.Map<IList<ProductOrderDto>>(productsInOrder);
        }

        private bool IsValidProductsInBasket(List<ProductBasket> productsInBasket, CreateOrderDto createOrder)
        {
            var desiredProductsToOrder = createOrder.ProductIds
                .GroupBy(x => x)
                .Select(x => new { ProductId = x.Key, Count = x.Count() });

            foreach (var product in desiredProductsToOrder)
            {
                var productFromBasket = GetProductFromBasket(productsInBasket, product.ProductId);

                if (product.Count > productFromBasket.Product.Amount)
                {
                    return false;
                }
            }
            return true;
        }

        private ProductBasket GetProductFromBasket(List<ProductBasket> productsInBasket, int productId)
        {
            var productFromBasket = productsInBasket.FirstOrDefault(x => x.ProductId == productId);

            if (productFromBasket == null)
            {
                throw new NotFoundException(nameof(ProductBasket), productId);
            }

            return productFromBasket;
        }

        private List<ProductOrder> AddProductsInOrder(CreateOrderDto createOrder)
        {
            var productsToOrder = new List<ProductOrder>();

            var groupedProducts = createOrder.ProductIds
                .GroupBy(x => x)
                .Select(x => new { ProductId = x.Key, Count = x.Count() });

            foreach (var product in groupedProducts)
            {
                productsToOrder.Add(new ProductOrder() { ProductId = product.ProductId, ProductCount = product.Count });
            }

            return productsToOrder;
        }

        private void ReduceProductsInBasketAndStore(List<ProductBasket> productsInBasket, List<ProductOrder> productsInOrder)
        {
            foreach (var product in productsInOrder)
            {
                var basketProduct = productsInBasket.FirstOrDefault(x => x.ProductId == product.ProductId);

                basketProduct.Product.Amount -= product.ProductCount;
                basketProduct.ProductCount -= product.ProductCount;

                if (basketProduct.ProductCount == 0)
                {
                    _productBasketRepository.Delete(basketProduct);
                }
            }
        }

        private int GetUserId()
        {
            return Convert.ToInt32(_claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
