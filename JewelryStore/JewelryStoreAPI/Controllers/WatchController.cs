using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Kafka.Watch;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Redis;
using JewelryStoreAPI.Models.Watch;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IWatchProducerService _watchProducerService;
        private readonly IWatchCacheService _watchCacheService;
        private readonly IMapper _mapper;

        public WatchController(
            IWatchService watchService,
            IWatchProducerService watchProducerService,
            IWatchCacheService watchCacheService,
            IMapper mapper)
        {
            _watchService = watchService;
            _watchProducerService = watchProducerService;
            _watchCacheService = watchCacheService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAll()
        {
            var watches = await _watchCacheService.GetAllAsync();

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

        [HttpGet("Diameter/{diameterInMillimeters}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAllByDiameter(int diameterInMillimeters)
        {
            var watches = await _watchService.GetAllByDiameter(diameterInMillimeters);

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [HttpGet("Brand/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAllByBrandId(int id)
        {
            var watches = await _watchService.GetAllByBrandId(id);

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [HttpGet("Country/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<WatchModel>> GetAllByCountryId(int id)
        {
            var watches = await _watchService.GetAllByCountryId(id);

            return _mapper.Map<IList<WatchModel>>(watches);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateWatchModel createWatch)
        {
            var produceWatchDto = _mapper.Map<ProduceWatchDto>(createWatch);

            await _watchProducerService.ProduceAsync(produceWatchDto);

            return Created("Id", "Watch creation is in progress");
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveWatchModel removeWatch)
        {
            await _watchService.Delete(removeWatch.Id);

            return NoContent();
        }
    }
}
