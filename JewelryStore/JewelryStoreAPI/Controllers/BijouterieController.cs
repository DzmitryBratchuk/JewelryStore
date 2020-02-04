using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.Bijouterie;
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
        public async Task<IList<GetBijouterieModel>> GetAll()
        {
            var bijouteries = await _bijouterieService.GetAll();

            return _mapper.Map<IList<GetBijouterieModel>>(bijouteries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<GetBijouterieModel> GetById(int id)
        {
            var bijouterie = await _bijouterieService.GetById(id);

            return _mapper.Map<GetBijouterieModel>(bijouterie);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<GetBijouterieModel>> GetAllByBijouterieTypeId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBijouterieTypeId(id);

            return _mapper.Map<IList<GetBijouterieModel>>(bijouteries);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<GetBijouterieModel>> GetAllByBrandId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBrandId(id);

            return _mapper.Map<IList<GetBijouterieModel>>(bijouteries);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<GetBijouterieModel>> GetAllByCountryId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByCountryId(id);

            return _mapper.Map<IList<GetBijouterieModel>>(bijouteries);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBijouterieModel createBijouterie)
        {
            var bijouterie = _mapper.Map<CreateBijouterieDto>(createBijouterie);

            await _bijouterieService.Create(bijouterie);

            return CreatedAtAction(nameof(GetById), new { id = bijouterie.Id }, bijouterie);
        }

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var bijouterie = new RemoveBijouterieDto() { Id = id };

            await _bijouterieService.Delete(bijouterie);

            return NoContent();
        }
    }
}
