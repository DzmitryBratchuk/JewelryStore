using JewelryStoreAPI.Domain.Entities;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IBasketRepository : IBaseRepository<Basket>
    {
        Task<Basket> GetByUserLoginAsync(string login);
        Task<Basket> GetByUserIdAsync(int userId);
    }
}
