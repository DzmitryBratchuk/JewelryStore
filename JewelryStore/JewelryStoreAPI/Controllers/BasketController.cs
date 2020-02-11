using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.ProductBasket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IProductBasketService _productBasketService;
        private readonly IMapper _mapper;

        public BasketController(IProductBasketService productBasketService, IMapper mapper)
        {
            _productBasketService = productBasketService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<ProductBasketModel>> GetAllProductsInBasket()
        {
            var userId = GetUserId();

            var productBaskets = await _productBasketService.GetAllProductsInBasket(userId);

            return _mapper.Map<IList<ProductBasketModel>>(productBaskets);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ProductBasketModel> GetById(int id)
        {
            var userId = GetUserId();

            var productBasketDto = await _productBasketService.GetById(userId, id);

            return _mapper.Map<ProductBasketModel>(productBasketDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProductInBasket([FromBody] AddProductInBasketModel addProductInBasket)
        {
            var userId = GetUserId();

            var addProductInBasketDto = _mapper.Map<AddProductInBasketDto>(addProductInBasket);

            var productId = await _productBasketService.AddProductInBasket(userId, addProductInBasketDto);

            var productBasketDto = await _productBasketService.GetById(userId, productId);

            var productBasketModel = _mapper.Map<ProductBasketModel>(productBasketDto);

            return CreatedAtAction(nameof(GetById), new { id = productBasketModel.ProductId }, productBasketModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductBasketModel updateProductBasket)
        {
            var userId = GetUserId();

            var productBasket = _mapper.Map<UpdateProductBasketDto>(updateProductBasket);

            productBasket.ProductId = id;

            await _productBasketService.UpdateProductInBasket(userId, productBasket);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();

            var productBasket = new RemoveProductBasketDto() { ProductId = id };

            await _productBasketService.RemoveProductFromBasket(userId, productBasket);

            return NoContent();
        }

        private int GetUserId()
        {
            return Convert.ToInt32(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                .FirstOrDefault()?.Value);
        }
    }
}
