using JewelryStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IList<Order>> GetAllInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<IList<Order>> GetAllByUserIdAsync(int userId);
        Task<IList<Order>> GetAllByUserIdInTimeRangeAsync(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<IList<Order>> GetAllByUserLoginAsync(string login);
        Task<Order> GetByIdAsync(int orderId, string userLogin);
    }
}
