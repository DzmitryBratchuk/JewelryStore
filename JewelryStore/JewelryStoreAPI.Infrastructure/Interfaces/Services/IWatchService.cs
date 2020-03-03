using JewelryStoreAPI.Infrastructure.DTO.Watch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IWatchService
    {
        Task<WatchDto> GetByIdAsync(int id);
        Task<IList<WatchDto>> GetAllAsync();
        Task<IList<WatchDto>> GetAllByCountryIdAsync(int countryId);
        Task<IList<WatchDto>> GetAllByBrandIdAsync(int brandId);
        Task<IList<WatchDto>> GetAllByDiameterAsync(int diameterInMillimeters);
        Task<WatchDto> CreateAsync(CreateWatchDto createWatch);
        Task UpdateAsync(int id, UpdateWatchDto updateWatch);
        Task DeleteAsync(int id);
    }
}
