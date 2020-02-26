using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IProductBasketRepository : IBaseRepository<ProductBasket>
    {
        Task<ProductBasket> GetById(int productId, int basketId);
        Task<IList<ProductBasket>> GetAllByBasketId(int id);
        Task<IList<ProductBasket>> GetAllByUserId(int id);
    }
}
