using JewelryStoreAPI.Infrastructure.CommandsDTO;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Infrastructure.QueriesDTO;
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

        public BijouterieController(IBijouterieService bijouterieService)
        {
            _bijouterieService = bijouterieService;
        }

        // GET: api/Bijouterie
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<BijouterieQueryDTO>> GetAll()
        {
            return await _bijouterieService.GetAll();
        }

        // GET: api/Bijouterie/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BijouterieQueryDTO> GetById(int id)
        {
            return await _bijouterieService.GetById(id);
        }

        // GET: api/Bijouterie/GetAllByBijouterieTypeId/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<BijouterieQueryDTO>> GetAllByBijouterieTypeId(int id)
        {
            return await _bijouterieService.GetAllByBijouterieTypeId(id);
        }

        // GET: api/Bijouterie/GetAllByBrandId/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<BijouterieQueryDTO>> GetAllByBrandId(int id)
        {
            return await _bijouterieService.GetAllByBrandId(id);
        }

        // GET: api/Bijouterie/GetAllByCountryId/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<BijouterieQueryDTO>> GetAllByCountryId(int id)
        {
            return await _bijouterieService.GetAllByCountryId(id);
        }

        // POST: api/Bijouterie
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] BijouterieCommandDTO bijouterie)
        {
            await _bijouterieService.Create(bijouterie);

            return CreatedAtAction(nameof(GetById), new { id = bijouterie.Id }, bijouterie);
        }

        // PUT: api/Bijouterie/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] BijouterieCommandDTO bijouterie)
        {
            await _bijouterieService.Update(id, bijouterie);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _bijouterieService.Delete(id);

            return NoContent();
        }
    }
}
