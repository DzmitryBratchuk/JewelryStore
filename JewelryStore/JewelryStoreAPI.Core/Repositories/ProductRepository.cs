using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;

namespace JewelryStoreAPI.Core.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(JewelryStoredbContext context) : base(context)
        {
        }
    }
}
