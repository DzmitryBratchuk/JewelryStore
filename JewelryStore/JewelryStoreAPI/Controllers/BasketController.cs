using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.ProductBasket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
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
            var productBaskets = await _productBasketService.GetAllProductsInBasket();

            return _mapper.Map<IList<ProductBasketModel>>(productBaskets);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ProductBasketModel> GetById(int id)
        {
            var productBasketDto = await _productBasketService.GetById(id);

            return _mapper.Map<ProductBasketModel>(productBasketDto);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProductInBasket([FromBody] AddProductInBasketModel addProductInBasket)
        {
            var addProductInBasketDto = _mapper.Map<AddProductInBasketDto>(addProductInBasket);

            await _productBasketService.AddProductInBasket(addProductInBasketDto);

            var productBasketDto = await _productBasketService.GetById(addProductInBasketDto.ProductId);

            var productBasketModel = _mapper.Map<ProductBasketModel>(productBasketDto);

            return CreatedAtAction(nameof(GetById), new { id = productBasketModel.ProductId }, productBasketModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int productId, [FromBody] UpdateProductBasketModel updateBijouterie)
        {
            var productBasket = _mapper.Map<UpdateProductBasketDto>(updateBijouterie);

            await _productBasketService.UpdateProductInBasket(productId, productBasket);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var productBasket = new RemoveProductBasketDto() { ProductId = id };

            await _productBasketService.RemoveProductFromBasket(productBasket);

            return NoContent();
        }
    }
}
