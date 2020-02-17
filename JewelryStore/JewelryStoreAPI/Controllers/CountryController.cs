using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Country;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<CountryModel>> GetAll()
        {
            var countries = await _countryService.GetAll();

            return _mapper.Map<IList<CountryModel>>(countries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<CountryModel> GetById(int id)
        {
            var country = await _countryService.GetById(id);

            return _mapper.Map<CountryModel>(country);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCountryModel createCountry)
        {
            var createCountryDto = _mapper.Map<CreateCountryDto>(createCountry);

            var countryDto = await _countryService.Create(createCountryDto);

            var countryModel = _mapper.Map<CountryModel>(countryDto);

            return CreatedAtAction(nameof(GetById), new { id = countryModel.Id }, countryModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCountryModel updateCountry)
        {
            var country = _mapper.Map<UpdateCountryDto>(updateCountry);

            await _countryService.Update(id, country);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveCountryModel removeCountry)
        {
            await _countryService.Delete(removeCountry.Id);

            return NoContent();
        }
    }
}
