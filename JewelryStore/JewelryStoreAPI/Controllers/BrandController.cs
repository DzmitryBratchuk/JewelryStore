﻿using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Brand;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<BrandModel>> GetAll()
        {
            var brands = await _brandService.GetAll();

            return _mapper.Map<IList<BrandModel>>(brands);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BrandModel> GetById(int id)
        {
            var brand = await _brandService.GetById(id);

            return _mapper.Map<BrandModel>(brand);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBrandModel createBrand)
        {
            var createBrandDto = _mapper.Map<CreateBrandDto>(createBrand);

            var id = await _brandService.Create(createBrandDto);

            var brandDto = await _brandService.GetById(id);

            var brandModel = _mapper.Map<BrandModel>(brandDto);

            return CreatedAtAction(nameof(GetById), new { id = brandModel.Id }, brandModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBrandModel updateBrand)
        {
            var brand = _mapper.Map<UpdateBrandDto>(updateBrand);

            await _brandService.Update(id, brand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = new RemoveBrandDto() { Id = id };

            await _brandService.Delete(brand);

            return NoContent();
        }
    }
}
