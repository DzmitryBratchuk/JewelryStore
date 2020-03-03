using JewelryStoreAPI.Infrastructure.DTO.Brand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBrandService
    {
        Task<BrandDto> GetByIdAsync(int id);
        Task<IList<BrandDto>> GetAllAsync();
        Task<BrandDto> CreateAsync(CreateBrandDto createBrand);
        Task UpdateAsync(int id, UpdateBrandDto updateBrand);
        Task DeleteAsync(int id);
    }
}
