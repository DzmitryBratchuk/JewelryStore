using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class BijouterieRepository : BaseRepository<Bijouterie>, IBijouterieRepository
    {
        public BijouterieRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public override async Task<IList<Bijouterie>> GetAll()
        {
            return await _context.Bijouteries
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.BijouterieType)
                .ToListAsync();
        }

        public override async Task<Bijouterie> GetById(int id)
        {
            return await _context.Bijouteries
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.BijouterieType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Bijouterie>> GetAllByBijouterieTypeId(int id)
        {
            return await _context.Bijouteries
                .Where(x => x.BijouterieTypeId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.BijouterieType)
                .ToListAsync();
        }

        public async Task<IList<Bijouterie>> GetAllByBrandId(int id)
        {
            return await _context.Bijouteries
                .Where(x => x.BrandId == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.BijouterieType)
                .ToListAsync();
        }

        public async Task<IList<Bijouterie>> GetAllByCountryId(int id)
        {
            return await _context.Bijouteries
                .Where(x => x.Country.Id == id)
                .Include(x => x.Brand)
                .Include(x => x.Country)
                .Include(x => x.BijouterieType)
                .ToListAsync();
        }
    }
}
