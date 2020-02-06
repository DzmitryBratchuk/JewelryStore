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

        public override async Task<IList<Watch>> GetAll()
        {
            return await _context.Watches
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public override async Task<Watch> GetById(int id)
        {
            return await _context.Watches
                .Where(x => x.Id == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Watch>> GetAllByBrandId(int id)
        {
            return await _context.Watches
                .Where(x => x.BrandId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<IList<Watch>> GetAllByCountryId(int id)
        {
            return await _context.Watches
                .Where(x => x.CountryId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<IList<Watch>> GetAllByDiameter(int diameter)
        {
            return await _context.Watches
                .Where(x => x.DiameterMM == diameter)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .ToListAsync();
        }
    }
}
