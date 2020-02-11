using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.PreciousItem;
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

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAllByPreciousItemTypeId(int id)
        {
            var preciousItems = await _preciousItemService.GetAllByPreciousItemTypeId(id);

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAllByBrandId(int id)
        {
            var preciousItems = await _preciousItemService.GetAllByBrandId(id);

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemModel>> GetAllByCountryId(int id)
        {
            var preciousItems = await _preciousItemService.GetAllByCountryId(id);

            return _mapper.Map<IList<PreciousItemModel>>(preciousItems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreatePreciousItemModel createPreciousItem)
        {
            var createPreciousItemDto = _mapper.Map<CreatePreciousItemDto>(createPreciousItem);

            var id = await _preciousItemService.Create(createPreciousItemDto);

            var preciousItemDto = await _preciousItemService.GetById(id);

            var preciousItemModel = _mapper.Map<PreciousItemModel>(preciousItemDto);

            return CreatedAtAction(nameof(GetById), new { id = preciousItemModel.Id }, preciousItemModel);
        }

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var preciousItem = new RemovePreciousItemDto() { Id = id };

            await _preciousItemService.Delete(preciousItem);

            return NoContent();
        }
    }
}
