using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBijouterieService
    {
        Task<BijouterieDto> GetById(int id);
        Task<IList<BijouterieDto>> GetAll();
        Task<IList<BijouterieDto>> GetAllByCountryId(int countryId);
        Task<IList<BijouterieDto>> GetAllByBrandId(int brandId);
        Task<IList<BijouterieDto>> GetAllByBijouterieTypeId(int bijouterieTypeId);
        Task Create(CreateBijouterieDto createBijouterie);
        Task Update(int id, UpdateBijouterieDto updateBijouterie);
        Task Delete(RemoveBijouterieDto removeBijouterie);
    }
}
