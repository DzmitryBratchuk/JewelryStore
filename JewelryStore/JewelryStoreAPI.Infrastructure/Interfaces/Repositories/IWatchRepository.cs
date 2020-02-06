using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IWatchRepository : IBaseRepository<Watch>
    {
        Task<IList<Watch>> GetAllByCountryId(int id);
        Task<IList<Watch>> GetAllByBrandId(int id);
        Task<IList<Watch>> GetAllByDiameter(int diameter);
    }
}
