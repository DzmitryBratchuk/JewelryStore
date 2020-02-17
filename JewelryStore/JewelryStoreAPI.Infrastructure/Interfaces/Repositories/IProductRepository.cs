using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> GetAllByName(string name);
        Task<IList<Product>> GetAllByCountryName(string countryName);
        Task<IList<Product>> GetAllByBrandName(string brandName);
    }
}
