using JewelryStoreAPI.Infrastructure.DTO.Country;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface ICountryService
    {
        Task<CountryDto> GetById(int id);
        Task<IList<CountryDto>> GetAll();
        Task<CountryDto> Create(CreateCountryDto createCountry);
        Task Update(int id, UpdateCountryDto updateCountry);
        Task Delete(int id);
    }
}
