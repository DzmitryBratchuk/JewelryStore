using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBijouterieService
    {
        Task<BijouterieDto> GetByIdAsync(int id);
        Task<IList<BijouterieDto>> GetAllAsync();
        Task<IList<BijouterieDto>> GetAllByCountryIdAsync(int countryId);
        Task<IList<BijouterieDto>> GetAllByBrandIdAsync(int brandId);
        Task<IList<BijouterieDto>> GetAllByBijouterieTypeIdAsync(int bijouterieTypeId);
        Task<BijouterieDto> CreateAsync(CreateBijouterieDto createBijouterie);
        Task UpdateAsync(int id, UpdateBijouterieDto updateBijouterie);
        Task DeleteAsync(int id);
    }
}
