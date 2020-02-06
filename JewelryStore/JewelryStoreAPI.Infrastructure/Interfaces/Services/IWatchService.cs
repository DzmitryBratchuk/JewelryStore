using JewelryStoreAPI.Infrastructure.DTO.Watch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IWatchService
    {
        Task<WatchDto> GetById(int id);
        Task<IList<WatchDto>> GetAll();
        Task<IList<WatchDto>> GetAllByCountryId(int countryId);
        Task<IList<WatchDto>> GetAllByBrandId(int brandId);
        Task<IList<WatchDto>> GetAllByDiameter(int diameter);
        Task Create(CreateWatchDto createWatch);
        Task Update(int id, UpdateWatchDto updateWatch);
        Task Delete(RemoveWatchDto removeWatch);
    }
}
