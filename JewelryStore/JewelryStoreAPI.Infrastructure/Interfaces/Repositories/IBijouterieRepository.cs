using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IBijouterieRepository : IBaseRepository<Bijouterie>
    {
        Task<IList<Bijouterie>> GetAllByCountryIdAsync(int id);
        Task<IList<Bijouterie>> GetAllByBrandIdAsync(int id);
        Task<IList<Bijouterie>> GetAllByBijouterieTypeIdAsync(int id);
    }
}
