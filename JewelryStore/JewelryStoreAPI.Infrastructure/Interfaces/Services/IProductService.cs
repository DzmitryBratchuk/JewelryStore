using JewelryStoreAPI.Infrastructure.DTO.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetAllByNameAsync(string name);
        Task<IList<ProductDto>> GetAllByBrandNameAsync(string brandName);
        Task<IList<ProductDto>> GetAllByCountryNameAsync(string countryName);
    }
}
