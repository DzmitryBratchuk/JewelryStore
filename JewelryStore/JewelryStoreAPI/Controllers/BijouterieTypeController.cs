using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.BijouterieType;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.BijouterieType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BijouterieTypeController : ControllerBase
    {
        private readonly IBijouterieTypeService _bijouterieTypeService;
        private readonly IMapper _mapper;

        public BijouterieTypeController(IBijouterieTypeService bijouterieTypeService, IMapper mapper)
        {
            _bijouterieTypeService = bijouterieTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BijouterieTypeModel>> GetAll()
        {
            var bijouterieTypes = await _bijouterieTypeService.GetAll();

            return _mapper.Map<IList<BijouterieTypeModel>>(bijouterieTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BijouterieTypeModel> GetById(int id)
        {
            var bijouterieType = await _bijouterieTypeService.GetById(id);

            return _mapper.Map<BijouterieTypeModel>(bijouterieType);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBijouterieTypeModel createBijouterieType)
        {
            var createBijouterieTypeDto = _mapper.Map<CreateBijouterieTypeDto>(createBijouterieType);

            var id = await _bijouterieTypeService.Create(createBijouterieTypeDto);

            var bijouterieTypeDto = await _bijouterieTypeService.GetById(id);

            var bijouterieTypeModel = _mapper.Map<BijouterieTypeModel>(bijouterieTypeDto);

            return CreatedAtAction(nameof(GetById), new { id = bijouterieTypeModel.Id }, bijouterieTypeModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBijouterieTypeModel updateBijouterieType)
        {
            var bijouterieType = _mapper.Map<UpdateBijouterieTypeDto>(updateBijouterieType);

            await _bijouterieTypeService.Update(id, bijouterieType);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var bijouterieType = new RemoveBijouterieTypeDto() { Id = id };

            await _bijouterieTypeService.Delete(bijouterieType);

            return NoContent();
        }
    }
}
