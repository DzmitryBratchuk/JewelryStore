using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    class JewelryStoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public Task Create(TEntity entity, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task Delete(object id, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity, bool shouldSaveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
