using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class BijouterieRepository : BaseRepository<Bijouterie>, IBijouterieRepository
    {
        public BijouterieRepository(JewelryStoredbContext context) : base(context)
        {
        }
        public async Task<IList<Bijouterie>> GetAllByBijouterieTypeId(int id)
        {
            return await _context.Bijouteries.Where(x => x.BijouterieTypeId == id).ToListAsync();
        }

        public async Task<IList<Bijouterie>> GetAllByBrandId(int id)
        {
            return await _context.Bijouteries.Where(x => x.BrandId == id).ToListAsync();
        }

        public async Task<IList<Bijouterie>> GetAllByCountryId(int id)
        {
            return await _context.Bijouteries.Where(x => x.CountryId == id).ToListAsync();
        }
    }
}
