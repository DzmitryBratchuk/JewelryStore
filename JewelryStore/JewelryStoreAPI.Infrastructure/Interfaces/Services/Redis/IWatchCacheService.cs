using JewelryStoreAPI.Infrastructure.DTO.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services.Redis
{
    public interface IWatchCacheService
    {
        Task<IList<WatchCacheDto>> GetAllAsync();
    }
}
