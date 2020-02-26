using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.PreciousItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciousItemController : ControllerBase
    {
        private readonly IPreciousItemService _preciousItemService;
        private readonly IMapper _mapper;

        public PreciousItemController(IPreciousItemService preciousItemService, IMapper mapper)
        {
            _preciousItemService = preciousItemService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAll()
        {
            var preciousItems = await _preciousItemService.GetAll();

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PreciousItemModel> GetById(int id)
        {
            var preciousItem = await _preciousItemService.GetById(id);

            return _mapper.Map<PreciousItemModel>(preciousItem);
        }

        [HttpGet("PreciousItemType/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAllByPreciousItemTypeId(int id)
        {
            var preciousItems = await _preciousItemService.GetAllByPreciousItemTypeId(id);

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [HttpGet("Brand/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAllByBrandId(int id)
        {
            var preciousItems = await _preciousItemService.GetAllByBrandId(id);

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [HttpGet("Country/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAllByCountryId(int id)
        {
            var preciousItems = await _preciousItemService.GetAllByCountryId(id);

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreatePreciousItemModel createPreciousItem)
        {
            var createPreciousItemDto = _mapper.Map<CreatePreciousItemDto>(createPreciousItem);

            var preciousItemDto = await _preciousItemService.Create(createPreciousItemDto);

            var preciousItemModel = _mapper.Map<PreciousItemModel>(preciousItemDto);

            return CreatedAtAction(nameof(GetById), new { id = preciousItemModel.Id }, preciousItemModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePreciousItemModel updatePreciousItem)
        {
            var preciousItem = _mapper.Map<UpdatePreciousItemDto>(updatePreciousItem);

            await _preciousItemService.Update(id, preciousItem);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemovePreciousItemModel removePreciousItem)
        {
            await _preciousItemService.Delete(removePreciousItem.Id);

            return NoContent();
        }
    }
}
