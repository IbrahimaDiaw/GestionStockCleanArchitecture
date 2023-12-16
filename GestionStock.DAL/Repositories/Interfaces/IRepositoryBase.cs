using GestionStock.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllWithDependances();
        Task<TEntity> InsertAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        void DeleteAsync(TEntity model);
    }
}
