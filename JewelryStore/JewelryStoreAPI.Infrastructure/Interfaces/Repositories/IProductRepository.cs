using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> GetAllByNameAsync(string name);
        Task<IList<Product>> GetAllByCountryNameAsync(string countryName);
        Task<IList<Product>> GetAllByBrandNameAsync(string brandName);
    }
}
