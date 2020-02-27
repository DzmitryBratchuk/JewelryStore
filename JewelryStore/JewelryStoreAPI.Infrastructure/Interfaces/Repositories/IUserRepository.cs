using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByIdAndPasswordAsync(int id, string passwordHash);
        Task<User> GetByLoginAndPasswordAsync(string login, string passwordHash);
        Task<IList<User>> GetAllByRoleIdAsync(int id);
    }
}
