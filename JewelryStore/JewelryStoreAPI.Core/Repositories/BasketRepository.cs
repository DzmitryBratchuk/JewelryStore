using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public async Task<Basket> GetByUserLoginAsync(string login)
        {
            return await _context.Baskets
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.User.Login == login);
        }

        public async Task<Basket> GetByUserIdAsync(int userId)
        {
            return await _context.Baskets
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.User.Id == userId);
        }
    }
}
