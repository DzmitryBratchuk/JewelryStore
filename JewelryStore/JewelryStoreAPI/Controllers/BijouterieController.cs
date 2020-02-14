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
            var bijouteries = await _bijouterieService.GetAll();

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BijouterieModel> GetById(int id)
        {
            var bijouterie = await _bijouterieService.GetById(id);

            return _mapper.Map<BijouterieModel>(bijouterie);
        }

        [HttpGet("GetAllByBijouterieTypeId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByBijouterieTypeId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBijouterieTypeId(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [HttpGet("GetAllByBrandId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByBrandId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBrandId(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [HttpGet("GetAllByCountryId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByCountryId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByCountryId(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBijouterieModel createBijouterie)
        {
            var createBijouterieDto = _mapper.Map<CreateBijouterieDto>(createBijouterie);

            var bijouterieDto = await _bijouterieService.Create(createBijouterieDto);

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

            await _bijouterieService.Update(id, bijouterie);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveBijouterieModel removeBijouterie)
        {
            var bijouterie = _mapper.Map<RemoveBijouterieDto>(removeBijouterie);

            await _bijouterieService.Delete(bijouterie);

            return NoContent();
        }
    }
}
