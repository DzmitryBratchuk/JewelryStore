using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public async Task<Basket> GetByUserLogin(string login)
        {
            return await _context.Baskets
                .Where(x => x.User.Login == login)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
        }
    }
}
