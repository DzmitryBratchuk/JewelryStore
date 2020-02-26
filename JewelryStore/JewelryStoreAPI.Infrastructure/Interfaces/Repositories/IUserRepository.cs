using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByLogin(string login);
        Task<User> GetByIdAndPassword(int id, string passwordHash);
        Task<User> GetByLoginAndPassword(string login, string passwordHash);
        Task<IList<User>> GetAllByRoleId(int id);
    }
}
