﻿using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.PreciousItemType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("[action]/{metalTypeName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<PreciousItemTypeModel>> GetAllByMetalTypeName(string metalTypeName)
        {
            var preciousItemTypes = await _preciousItemTypeService.GetAllByMetalTypeName(metalTypeName);

            return _mapper.Map<IList<PreciousItemTypeModel>>(preciousItemTypes);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreatePreciousItemTypeModel createPreciousItemType)
        {
            var createPreciousItemTypeDto = _mapper.Map<CreatePreciousItemTypeDto>(createPreciousItemType);

            await _preciousItemTypeService.Create(createPreciousItemTypeDto);

            var preciousItemTypeDto = await _preciousItemTypeService.GetById(createPreciousItemTypeDto.Id);

            var preciousItemTypeModel = _mapper.Map<PreciousItemTypeModel>(preciousItemTypeDto);

            return CreatedAtAction(nameof(GetById), new { id = preciousItemTypeModel.Id }, preciousItemTypeModel);
        }

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var preciousItemType = new RemovePreciousItemTypeDto() { Id = id };

            await _preciousItemTypeService.Delete(preciousItemType);

            return NoContent();
        }
    }
}
