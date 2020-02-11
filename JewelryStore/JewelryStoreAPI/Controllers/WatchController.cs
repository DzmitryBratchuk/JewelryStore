using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.Watch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly IWatchService _watchService;
        private readonly IMapper _mapper;

        public WatchController(IWatchService watchService, IMapper mapper)
        {
            _watchService = watchService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAll()
        {
            var watches = await _watchService.GetAll();

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<WatchModel> GetById(int id)
        {
            var watch = await _watchService.GetById(id);

            return _mapper.Map<WatchModel>(watch);
        }

        [HttpGet("[action]/{diameterInMillimeters}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAllByDiameter(int diameterInMillimeters)
        {
            var watches = await _watchService.GetAllByDiameter(diameterInMillimeters);

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAllByBrandId(int id)
        {
            var watches = await _watchService.GetAllByBrandId(id);

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAllByCountryId(int id)
        {
            var watches = await _watchService.GetAllByCountryId(id);

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateWatchModel createWatch)
        {
            var createWatchDto = _mapper.Map<CreateWatchDto>(createWatch);

            var id = await _watchService.Create(createWatchDto);

            var watchDto = await _watchService.GetById(id);

            var watchModel = _mapper.Map<WatchModel>(watchDto);

            return CreatedAtAction(nameof(GetById), new { id = watchModel.Id }, watchModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateWatchModel updateWatch)
        {
            var watch = _mapper.Map<UpdateWatchDto>(updateWatch);

            await _watchService.Update(id, watch);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var watch = new RemoveWatchDto() { Id = id };

            await _watchService.Delete(watch);

            return NoContent();
        }
    }
}
