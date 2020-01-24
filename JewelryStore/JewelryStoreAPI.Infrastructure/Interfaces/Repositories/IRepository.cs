using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable
            where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(object id);
        Task Create(TEntity entity, bool shouldSaveChanges = true);
        Task Update(TEntity entity, bool shouldSaveChanges = true);
        Task Delete(object id, bool shouldSaveChanges = true);
        Task<int> SaveChanges();
    }
}
