using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Core.Repositories
{
    public class JewelryStoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly JewelryStoredbContext _context;

        private bool disposed = false;

        public JewelryStoreRepository(JewelryStoredbContext context)
        {
            _context = context;
        }

        public async Task Create(TEntity entity, bool shouldSaveChanges = true)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            if (shouldSaveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task Delete(object id, bool shouldSaveChanges = true)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
                _context.Set<TEntity>().Remove(entity);
            if (shouldSaveChanges)
                await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity> GetById(object id)
        {
            return _context.Set<TEntity>().FindAsync(id).AsTask();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity, bool shouldSaveChanges = true)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (shouldSaveChanges)
                await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
