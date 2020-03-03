using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class WatchRepository : BaseRepository<Watch>, IWatchRepository
    {
        public WatchRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public override async Task<IList<Watch>> GetAllAsync()
        {
            return await _context.Watches
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public override async Task<Watch> GetByIdAsync(int id)
        {
            return await _context.Watches
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Watch>> GetAllByBrandIdAsync(int id)
        {
            return await _context.Watches
                .Where(x => x.BrandId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<IList<Watch>> GetAllByCountryIdAsync(int id)
        {
            return await _context.Watches
                .Where(x => x.CountryId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<IList<Watch>> GetAllByDiameterAsync(int diameterInMillimeters)
        {
            return await _context.Watches
                .Where(x => x.DiameterMM == diameterInMillimeters)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }
    }
}
