using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;

namespace JewelryStoreAPI.Core.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(JewelryStoredbContext context) : base(context)
        {
        }
    }
}
