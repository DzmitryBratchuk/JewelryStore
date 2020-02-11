using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductBasketRepository _productBasketRepository;
        private readonly IMapper _mapper;

        public ProductOrderService(
            IProductOrderRepository productOrderRepository,
            IOrderRepository orderRepository,
            IProductBasketRepository productBasketRepository,
            IMapper mapper)
        {
            _productOrderRepository = productOrderRepository;
            _orderRepository = orderRepository;
            _productBasketRepository = productBasketRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProductOrderDto>> GetAllProductsInOrder(int userId, int orderId)
        {
            var entities = await _productOrderRepository.GetAllByOrderId(userId, orderId);

            return _mapper.Map<IList<ProductOrderDto>>(entities);
        }

        public async Task<IList<OrderDto>> GetAllUserOrders(int userId)
        {
            var orders = await _orderRepository.GetAllByUserId(userId);

            return _mapper.Map<IList<OrderDto>>(orders);
        }

        public async Task<int> CreateOrder(int userId, CreateOrderDto createOrder)
        {
            var productsInBasket = await _productBasketRepository.GetAllByUserId(userId)
                .ContinueWith(x => x.Result as List<ProductBasket>);

            var productsInOrder = new List<ProductOrder>();

            foreach (var productId in createOrder.ProductIds)
            {
                var productBasketItem = productsInBasket.Find(x => x.ProductId == productId);

                if (productBasketItem == null)
                {
                    throw new NotFoundException(nameof(ProductBasket), productId);
                }

                var productOrderItem = productsInOrder.Find(x => x.ProductId == productId);

                if (productOrderItem == null)
                {
                    productOrderItem = new ProductOrder() { ProductId = productId };
                    productsInOrder.Add(productOrderItem);
                }

                if (productOrderItem.ProductCount > productBasketItem.Product.Amount)
                {
                    throw new NotFoundException($"Not enough products ({productBasketItem.Product.Name}) in store.");
                }

                productOrderItem.ProductCount++;
                productBasketItem.Product.Amount--;
                productBasketItem.ProductCount--;

                if (productBasketItem.ProductCount == 0)
                {
                    _productBasketRepository.Delete(productBasketItem);
                }
            }

            var entity = new Order()
            {
                ProductOrders = productsInOrder,
                OrderTime = DateTimeOffset.UtcNow,
                UserId = userId,
            };

            await _orderRepository.Create(entity);
            await _orderRepository.SaveChangesAsync();
            await _productBasketRepository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
