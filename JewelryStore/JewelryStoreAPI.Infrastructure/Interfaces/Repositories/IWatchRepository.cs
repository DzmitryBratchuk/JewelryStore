using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IWatchRepository : IBaseRepository<Watch>
    {
        Task<IList<Watch>> GetAllByCountryIdAsync(int id);
        Task<IList<Watch>> GetAllByBrandIdAsync(int id);
        Task<IList<Watch>> GetAllByDiameterAsync(int diameterInMillimeters);
    }
}
