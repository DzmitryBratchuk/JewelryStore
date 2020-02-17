using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.ProductBasket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProductInBasket([FromBody] AddProductInBasketModel addProductInBasket)
        {
            var addProductInBasketDto = _mapper.Map<AddProductInBasketDto>(addProductInBasket);

            var productBasketDto = await _productBasketService.AddProductInBasket(addProductInBasketDto);

            var productBasketModel = _mapper.Map<ProductBasketModel>(productBasketDto);

            return CreatedAtAction(nameof(GetById), new { id = productBasketModel.ProductId }, productBasketModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductBasketModel updateProductBasket)
        {
            var productBasket = _mapper.Map<UpdateProductBasketDto>(updateProductBasket);

            productBasket.ProductId = id;

            await _productBasketService.UpdateProductInBasket(productBasket);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductBasketModel removeProductBasket)
        {
            await _productBasketService.RemoveProductFromBasket(removeProductBasket.Id);

            return NoContent();
        }
    }
}
