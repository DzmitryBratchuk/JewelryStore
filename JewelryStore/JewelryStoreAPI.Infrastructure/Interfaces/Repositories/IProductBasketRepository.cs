using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IProductBasketRepository : IBaseRepository<ProductBasket>
    {
        Task<ProductBasket> GetByIdAsync(int productId, int basketId);
        Task<IList<ProductBasket>> GetAllByBasketIdAsync(int id);
        Task<IList<ProductBasket>> GetAllByUserIdAsync(int id);
    }
}
