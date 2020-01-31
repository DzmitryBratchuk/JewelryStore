using JewelryStoreAPI.Infrastructure.CommandsDTO;
using JewelryStoreAPI.Infrastructure.QueriesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IBijouterieService
    {
        Task<BijouterieQueryDTO> GetById(object id);
        Task<IList<BijouterieQueryDTO>> GetAll();
        Task<IList<BijouterieQueryDTO>> GetAllByCountryId(int countryId);
        Task<IList<BijouterieQueryDTO>> GetAllByBrandId(int brandId);
        Task<IList<BijouterieQueryDTO>> GetAllByBijouterieTypeId(int bijouterieTypeId);
        Task Create(BijouterieCommandDTO bijouterieCommand);
        Task Update(int id, BijouterieCommandDTO bijouterieCommand);
        Task Delete(int id);
    }
}
