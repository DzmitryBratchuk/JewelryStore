using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class ProductBasketRepository : BaseRepository<ProductBasket>, IProductBasketRepository
    {
        public ProductBasketRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public async Task<ProductBasket> GetByIdAsync(int productId, int basketId)
        {
            return await _context.ProductBaskets
                .Include(x => x.Basket)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.BasketId == basketId);
        }

        public async Task<IList<ProductBasket>> GetAllByBasketIdAsync(int id)
        {
            return await _context.ProductBaskets
                .Where(x => x.BasketId == id)
                .Include(x => x.Basket)
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<IList<ProductBasket>> GetAllByUserIdAsync(int id)
        {
            return await _context.ProductBaskets
                .Where(x => x.Basket.UserId == id)
                .Include(x => x.Basket)
                .Include(x => x.Product)
                .ToListAsync();
        }
    }
}
