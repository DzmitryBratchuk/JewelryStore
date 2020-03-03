using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Bijouterie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BijouterieController : ControllerBase
    {
        private readonly IBijouterieService _bijouterieService;
        private readonly IMapper _mapper;

        public BijouterieController(IBijouterieService bijouterieService, IMapper mapper)
        {
            _bijouterieService = bijouterieService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAll()
        {
            var bijouteries = await _bijouterieService.GetAllAsync();

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BijouterieModel> GetById(int id)
        {
            var bijouterie = await _bijouterieService.GetByIdAsync(id);

            return _mapper.Map<BijouterieModel>(bijouterie);
        }

        [HttpGet("BijouterieType/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByBijouterieTypeId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBijouterieTypeIdAsync(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [HttpGet("Brand/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByBrandId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBrandIdAsync(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [HttpGet("Country/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByCountryId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByCountryIdAsync(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBijouterieModel createBijouterie)
        {
            var createBijouterieDto = _mapper.Map<CreateBijouterieDto>(createBijouterie);

            var bijouterieDto = await _bijouterieService.CreateAsync(createBijouterieDto);

            var bijouterieModel = _mapper.Map<BijouterieModel>(bijouterieDto);

            return CreatedAtAction(nameof(GetById), new { id = bijouterieModel.Id }, bijouterieModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBijouterieModel updateBijouterie)
        {
            var bijouterie = _mapper.Map<UpdateBijouterieDto>(updateBijouterie);

            await _bijouterieService.UpdateAsync(id, bijouterie);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveBijouterieModel removeBijouterie)
        {
            await _bijouterieService.DeleteAsync(removeBijouterie.Id);

            return NoContent();
        }
    }
}
