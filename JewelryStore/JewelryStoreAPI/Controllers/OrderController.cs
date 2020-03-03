using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Order;
using JewelryStoreAPI.Models.ProductOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Authorize]
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
            var orders = await _productOrderService.GetAllUserOrdersAsync();

            return _mapper.Map<IList<OrderModel>>(orders);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<ProductOrderModel>> GetAllProductsInOrder(int id)
        {
            var productOrder = await _productOrderService.GetAllProductsInOrderAsync(id);

            return _mapper.Map<IList<ProductOrderModel>>(productOrder);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel createOrder)
        {
            var createOrderDto = _mapper.Map<CreateOrderDto>(createOrder);

            var productOrderDto = await _productOrderService.CreateOrderAsync(createOrderDto);

            var productOrderModel = _mapper.Map<IList<ProductOrderModel>>(productOrderDto);

            return CreatedAtAction(nameof(GetAllProductsInOrder), new { id = productOrderModel.First().ProductId }, productOrderModel);
        }
    }
}
