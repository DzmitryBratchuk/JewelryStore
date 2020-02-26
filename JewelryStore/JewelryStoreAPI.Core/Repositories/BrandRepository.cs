using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;

namespace JewelryStoreAPI.Core.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(JewelryStoredbContext context) : base(context)
        {
        }
    }
}
