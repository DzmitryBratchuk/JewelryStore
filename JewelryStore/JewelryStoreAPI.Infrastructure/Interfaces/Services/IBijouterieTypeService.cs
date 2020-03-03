using JewelryStoreAPI.Infrastructure.DTO.BijouterieType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBijouterieTypeService
    {
        Task<BijouterieTypeDto> GetByIdAsync(int id);
        Task<IList<BijouterieTypeDto>> GetAllAsync();
        Task<BijouterieTypeDto> CreateAsync(CreateBijouterieTypeDto createBijouterieType);
        Task UpdateAsync(int id, UpdateBijouterieTypeDto updateBijouterieType);
        Task DeleteAsync(int id);
    }
}
