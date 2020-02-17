using JewelryStoreAPI.Infrastructure.DTO.BijouterieType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBijouterieTypeService
    {
        Task<BijouterieTypeDto> GetById(int id);
        Task<IList<BijouterieTypeDto>> GetAll();
        Task<BijouterieTypeDto> Create(CreateBijouterieTypeDto createBijouterieType);
        Task Update(int id, UpdateBijouterieTypeDto updateBijouterieType);
        Task Delete(int id);
    }
}
