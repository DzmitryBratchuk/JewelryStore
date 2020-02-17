using JewelryStoreAPI.Infrastructure.DTO.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetAllByName(string name);
        Task<IList<ProductDto>> GetAllByBrandName(string brandName);
        Task<IList<ProductDto>> GetAllByCountryName(string countryName);
    }
}
