using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public async Task<IList<Product>> GetAllByNameAsync(string name)
        {
            return await _context.Products
                .Where(x => x.Name.StartsWith(name))
                .ToListAsync();
        }

        public async Task<IList<Product>> GetAllByBrandNameAsync(string brandName)
        {
            return await _context.Products
                .Where(x => x.Brand.Name.StartsWith(brandName))
                .ToListAsync();
        }

        public async Task<IList<Product>> GetAllByCountryNameAsync(string countryName)
        {
            return await _context.Products
                .Where(x => x.Country.Name.StartsWith(countryName))
                .ToListAsync();
        }
    }
}
