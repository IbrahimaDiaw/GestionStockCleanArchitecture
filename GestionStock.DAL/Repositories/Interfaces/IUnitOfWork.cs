using GestionStock.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork<TEntity> where TEntity : class, IEntity
    {
        IGenericRepository<TEntity> Repository { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
