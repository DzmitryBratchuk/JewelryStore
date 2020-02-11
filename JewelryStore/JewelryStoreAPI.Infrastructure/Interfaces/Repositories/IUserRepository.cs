﻿using JewelryStoreAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByLogin(string login);
        Task<User> GetByIdAndPassword(int id, byte[] passwordHash);
        Task<User> GetByLoginAndPassword(string login, byte[] passwordHash);
        Task<IList<User>> GetAllByRoleId(int id);
    }
}
