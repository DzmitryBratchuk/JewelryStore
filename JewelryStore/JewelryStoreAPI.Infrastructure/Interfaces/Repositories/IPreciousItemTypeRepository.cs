using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IPreciousItemTypeRepository : IBaseRepository<PreciousItemType>
    {
        Task<IList<PreciousItemType>> GetAllByMetalTypeAsync(MetalType metalType);
    }
}
