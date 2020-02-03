using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBijouterieService
    {
        Task<GetBijouterieDto> GetById(object id);
        Task<IList<GetBijouterieDto>> GetAll();
        Task<IList<GetBijouterieDto>> GetAllByCountryId(int countryId);
        Task<IList<GetBijouterieDto>> GetAllByBrandId(int brandId);
        Task<IList<GetBijouterieDto>> GetAllByBijouterieTypeId(int bijouterieTypeId);
        Task Create(CreateBijouterieDto createBijouterie);
        Task Update(int id, UpdateBijouterieDto updateBijouterie);
        Task Delete(RemoveBijouterieDto removeBijouterie);
    }
}
