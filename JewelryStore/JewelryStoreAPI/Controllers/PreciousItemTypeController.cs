using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.PreciousItemType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciousItemTypeController : ControllerBase
    {
        private readonly IPreciousItemTypeService _preciousItemTypeService;
        private readonly IMapper _mapper;

        public PreciousItemTypeController(IPreciousItemTypeService preciousItemTypeService, IMapper mapper)
        {
            _preciousItemTypeService = preciousItemTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemTypeModel>> GetAll()
        {
            var preciousItemTypes = await _preciousItemTypeService.GetAll();

            return _mapper.Map<IList<PreciousItemTypeModel>>(preciousItemTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PreciousItemTypeModel> GetById(int id)
        {
            var preciousItemType = await _preciousItemTypeService.GetById(id);

            return _mapper.Map<PreciousItemTypeModel>(preciousItemType);
        }

        [HttpGet("GetAllByMetalTypeName/{metalTypeName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemTypeModel>> GetAllByMetalTypeName(string metalTypeName)
        {
            var result = Enum.TryParse(metalTypeName, out MetalType metalType);

            if (!result)
            {
                throw new BadRequestException($" '{nameof(MetalType)}' has a range of values which does not include '{metalTypeName}'");
            }

            var preciousItemTypes = await _preciousItemTypeService.GetAllByMetalType(metalType);

            return _mapper.Map<IList<PreciousItemTypeModel>>(preciousItemTypes);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreatePreciousItemTypeModel createPreciousItemType)
        {
            var createPreciousItemTypeDto = _mapper.Map<CreatePreciousItemTypeDto>(createPreciousItemType);

            var preciousItemTypeDto = await _preciousItemTypeService.Create(createPreciousItemTypeDto);

            var preciousItemTypeModel = _mapper.Map<PreciousItemTypeModel>(preciousItemTypeDto);

            return CreatedAtAction(nameof(GetById), new { id = preciousItemTypeModel.Id }, preciousItemTypeModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePreciousItemTypeModel updatePreciousItemType)
        {
            var preciousItemType = _mapper.Map<UpdatePreciousItemTypeDto>(updatePreciousItemType);

            await _preciousItemTypeService.Update(id, preciousItemType);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemovePreciousItemTypeModel removePreciousItemType)
        {
            await _preciousItemTypeService.Delete(removePreciousItemType.Id);

            return NoContent();
        }
    }
}
