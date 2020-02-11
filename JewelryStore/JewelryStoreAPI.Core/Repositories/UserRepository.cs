using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JewelryStoredbContext context) : base(context)
        {
        }

        public override async Task<IList<User>> GetAll()
        {
            return await _context.Users
                .Include(x => x.Role)
                .ToListAsync();
        }

        public override async Task<User> GetById(int id)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<User>> GetAllByRoleId(int id)
        {
            return await _context.Users
                .Where(x => x.RoleId == id)
                .Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<User> GetByIdAndPassword(int id, byte[] passwordHash)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id && x.PasswordHash.SequenceEqual(passwordHash));
        }

        public async Task<User> GetByLoginAndPassword(string login, byte[] passwordHash)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login == login && x.PasswordHash.SequenceEqual(passwordHash));
        }
    }
}
