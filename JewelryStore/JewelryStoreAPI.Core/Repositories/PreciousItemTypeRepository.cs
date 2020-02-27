using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class PreciousItemTypeRepository : BaseRepository<PreciousItemType>, IPreciousItemTypeRepository
    {
        public PreciousItemTypeRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public async Task<IList<PreciousItemType>> GetAllByMetalTypeAsync(MetalType metalType)
        {
            return await _context.PreciousItemTypes
                .Where(x => x.MetalType == metalType)
                .ToListAsync();
        }
    }
}
