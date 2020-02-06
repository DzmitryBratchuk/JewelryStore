using JewelryStoreAPI.Domain.Entities;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IBasketRepository : IBaseRepository<Basket>
    {
        Task<Basket> GetByUserLogin(string login);
    }
}
