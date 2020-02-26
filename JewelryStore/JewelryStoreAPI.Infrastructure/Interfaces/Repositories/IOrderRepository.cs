using JewelryStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IList<Order>> GetAllInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<IList<Order>> GetAllByUserId(int userId);
        Task<IList<Order>> GetAllByUserIdInTimeRange(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<IList<Order>> GetAllByUserLogin(string login);
        Task<Order> GetById(int orderId, string userLogin);
    }
}
