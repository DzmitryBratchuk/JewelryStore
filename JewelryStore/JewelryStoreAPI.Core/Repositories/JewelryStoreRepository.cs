using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private JewelryStoredbContext _db;

        public JewelryStoreRepository(JewelryStoredbContext db)
        {
            _db = db;
        }

        public async Task Create(TEntity entity, bool shouldSaveChanges = true)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            if (shouldSaveChanges)
                await _db.SaveChangesAsync();
        }

        public async Task Delete(object id, bool shouldSaveChanges = true)
        {
            TEntity entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity != null)
                _db.Set<TEntity>().Remove(entity);
            if (shouldSaveChanges)
                await _db.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity> GetById(object id)
        {
            return _db.Set<TEntity>().FindAsync(id).AsTask();
        }

        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public async Task Update(TEntity entity, bool shouldSaveChanges = true)
        {
            _db.Entry(entity).State = EntityState.Modified;
            if (shouldSaveChanges)
                await _db.SaveChangesAsync();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
