using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public override async Task<IList<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(x => x.User)
                .Include(x => x.ProductOrders)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetAllInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            return await _context.Orders
                .Where(x => x.OrderTime >= dateFrom && x.OrderTime <= dateTo)
                .Include(x => x.ProductOrders)
                    .ThenInclude(p => p.Product)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.ProductOrders)
                    .ThenInclude(p => p.Product)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetAllByUserIdInTimeRangeAsync(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            return await _context.Orders
                .Where(x => x.UserId == userId
                            && x.OrderTime >= dateFrom
                            && x.OrderTime <= dateTo)
                .Include(x => x.ProductOrders)
                    .ThenInclude(p => p.Product)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetAllByUserLoginAsync(string login)
        {
            return await _context.Orders
                .Where(x => x.User.Login == login)
                .Include(x => x.User)
                .Include(x => x.ProductOrders)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int orderId, string userLogin)
        {
            return await _context.Orders
                .Include(x => x.User)
                .Include(x => x.ProductOrders)
                .FirstOrDefaultAsync(x => x.Id == orderId && x.User.Login == userLogin);
        }
    }
}
