using JewelryStoreAPI.Infrastructure.DTO.Brand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBrandService
    {
        Task<BrandDto> GetById(int id);
        Task<IList<BrandDto>> GetAll();
        Task Create(CreateBrandDto createBrand);
        Task Update(int id, UpdateBrandDto updateBrand);
        Task Delete(RemoveBrandDto removeBrand);
    }
}
