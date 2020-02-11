using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class ProductOrderRepository : BaseRepository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public async Task<IList<ProductOrder>> GetAllByOrderId(int orderId)
        {
            return await _context.ProductOrders
                .Where(x => x.OrderId == orderId)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<IList<ProductOrder>> GetAllByOrderId(int userId, int orderId)
        {
            return await _context.ProductOrders
                .Where(x => x.Order.UserId == userId && x.OrderId == orderId)
                .Include(x => x.Order)
                .Include(x => x.Product)
                    .ThenInclude(b => b.Brand)
                .Include(x => x.Product)
                    .ThenInclude(c => c.Country)
                .ToListAsync();
        }
    }
}
