using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
            where TEntity : class
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(object id);
        Task Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
