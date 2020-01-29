using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IBijouterieRepository : IBaseRepository<Bijouterie>
    {
        Task<IList<Bijouterie>> GetAllByCountryId(int id);
        Task<IList<Bijouterie>> GetAllByBrandId(int id);
        Task<IList<Bijouterie>> GetAllByBijouterieTypeId(int id);
    }
}
