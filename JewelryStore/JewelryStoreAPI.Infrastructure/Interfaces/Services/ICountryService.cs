using JewelryStoreAPI.Infrastructure.DTO.Country;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface ICountryService
    {
        Task<CountryDto> GetByIdAsync(int id);
        Task<IList<CountryDto>> GetAllAsync();
        Task<CountryDto> CreateAsync(CreateCountryDto createCountry);
        Task UpdateAsync(int id, UpdateCountryDto updateCountry);
        Task DeleteAsync(int id);
    }
}
