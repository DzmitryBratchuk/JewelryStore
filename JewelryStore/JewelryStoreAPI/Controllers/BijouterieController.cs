using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations;
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

        // GET: api/Bijouterie
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAll()
        {
            var bijouteries = await _bijouterieService.GetAll();

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        // GET: api/Bijouterie/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BijouterieModel> GetById(int id)
        {
            var bijouterie = await _bijouterieService.GetById(id);

            return _mapper.Map<BijouterieModel>(bijouterie);
        }

        // GET: api/Bijouterie/GetAllByBijouterieTypeId/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByBijouterieTypeId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBijouterieTypeId(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        // GET: api/Bijouterie/GetAllByBrandId/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByBrandId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByBrandId(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        // GET: api/Bijouterie/GetAllByCountryId/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieModel>> GetAllByCountryId(int id)
        {
            var bijouteries = await _bijouterieService.GetAllByCountryId(id);

            return _mapper.Map<IList<BijouterieModel>>(bijouteries);
        }

        // POST: api/Bijouterie
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBijouterieDto bijouterie)
        {
            await _bijouterieService.Create(bijouterie);

            return CreatedAtAction(nameof(GetById), new { id = bijouterie.Id }, bijouterie);
        }

        // PUT: api/Bijouterie/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBijouterieDto bijouterie)
        {
            await _bijouterieService.Update(id, bijouterie);

            return NoContent();
        }

        // DELETE: api/Bijouterie
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] RemoveBijouterieDto bijouterie)
        {
            await _bijouterieService.Delete(bijouterie);

            return NoContent();
        }
    }
}
