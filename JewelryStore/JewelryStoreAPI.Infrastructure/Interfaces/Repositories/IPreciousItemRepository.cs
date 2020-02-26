using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IPreciousItemRepository : IBaseRepository<PreciousItem>
    {
        Task<IList<PreciousItem>> GetAllByCountryId(int id);
        Task<IList<PreciousItem>> GetAllByBrandId(int id);
        Task<IList<PreciousItem>> GetAllByPreciousItemTypeId(int id);
    }
}
