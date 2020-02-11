using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.Order;
using JewelryStoreAPI.Presentations.ProductOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IProductOrderService _productOrderService;
        private readonly IMapper _mapper;

        public OrderController(IProductOrderService productOrderService, IMapper mapper)
        {
            _productOrderService = productOrderService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<OrderModel>> GetAllUserOrders()
        {
            var userId = GetUserId();

            var orders = await _productOrderService.GetAllUserOrders(userId);

            return _mapper.Map<IList<OrderModel>>(orders);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<ProductOrderModel>> GetAllProductsInOrder(int id)
        {
            var userId = GetUserId();

            var productOrder = await _productOrderService.GetAllProductsInOrder(userId, id);

            return _mapper.Map<IList<ProductOrderModel>>(productOrder);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel createOrder)
        {
            var userId = GetUserId();

            var createOrderDto = _mapper.Map<CreateOrderDto>(createOrder);

            var orderId = await _productOrderService.CreateOrder(userId, createOrderDto);

            var productOrderDto = await _productOrderService.GetAllProductsInOrder(userId, orderId);

            var productOrderModel = _mapper.Map<IList<ProductOrderModel>>(productOrderDto);

            return CreatedAtAction(nameof(GetAllProductsInOrder), new { id = orderId }, productOrderModel);
        }

        private int GetUserId()
        {
            return Convert.ToInt32(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                .FirstOrDefault()?.Value);
        }
    }
}
