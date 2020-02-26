using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;

namespace JewelryStoreAPI.Core.Repositories
{
    public class BijouterieTypeRepository : BaseRepository<BijouterieType>, IBijouterieTypeRepository
    {
        public BijouterieTypeRepository(JewelryStoredbContext context) : base(context)
        {
        }
    }
}
