using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IProductOrderRepository : IBaseRepository<ProductOrder>
    {
        Task<IList<ProductOrder>> GetAllByOrderIdAsync(int orderId);
        Task<IList<ProductOrder>> GetAllByOrderIdAsync(int userId, int orderId);
    }
}
