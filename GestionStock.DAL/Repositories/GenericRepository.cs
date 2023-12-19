using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories
{
    public class GenericRepository<TEntity>(GestionStockDbContext dbContext) : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly GestionStockDbContext _dbContext = dbContext;

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            await Task.CompletedTask;
            if (_dbContext.Entry(entity).State == EntityState.Detached) _dbContext.Attach(entity);
            _dbContext.Set<TEntity>().Remove(entity);
            return true;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            await Task.CompletedTask;
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            TEntity? entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(item => item.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity Id {id} doesn't exist ");
            }
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return (await _dbContext.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }
            _dbContext.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
