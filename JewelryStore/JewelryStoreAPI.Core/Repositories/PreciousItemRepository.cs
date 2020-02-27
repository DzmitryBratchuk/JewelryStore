using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class PreciousItemRepository : BaseRepository<PreciousItem>, IPreciousItemRepository
    {
        public PreciousItemRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public override async Task<IList<PreciousItem>> GetAllAsync()
        {
            return await _context.PreciousItems
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.PreciousItemType)
                .ToListAsync();
        }

        public override async Task<PreciousItem> GetByIdAsync(int id)
        {
            return await _context.PreciousItems
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.PreciousItemType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<PreciousItem>> GetAllByBrandIdAsync(int id)
        {
            return await _context.PreciousItems
                .Where(x => x.BrandId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.PreciousItemType)
                .ToListAsync();
        }

        public async Task<IList<PreciousItem>> GetAllByCountryIdAsync(int id)
        {
            return await _context.PreciousItems
                .Where(x => x.CountryId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.PreciousItemType)
                .ToListAsync();
        }

        public async Task<IList<PreciousItem>> GetAllByPreciousItemTypeIdAsync(int id)
        {
            return await _context.PreciousItems
                .Where(x => x.PreciousItemTypeId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.PreciousItemType)
                .ToListAsync();
        }
    }
}
