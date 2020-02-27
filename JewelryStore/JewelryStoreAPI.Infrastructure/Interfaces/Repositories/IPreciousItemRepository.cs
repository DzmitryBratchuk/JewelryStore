using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IPreciousItemRepository : IBaseRepository<PreciousItem>
    {
        Task<IList<PreciousItem>> GetAllByCountryIdAsync(int id);
        Task<IList<PreciousItem>> GetAllByBrandIdAsync(int id);
        Task<IList<PreciousItem>> GetAllByPreciousItemTypeIdAsync(int id);
    }
}
