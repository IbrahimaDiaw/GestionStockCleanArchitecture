using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories
{
    public class UnitOfWork<TEntity>(GestionStockDbContext dbContext, IServiceProvider serviceProvider) : IUnitOfWork<TEntity>
        where TEntity : class, IEntity
    {
        private readonly GestionStockDbContext _dbContext = dbContext;
        public IGenericRepository<TEntity> Repository { get; set; } = serviceProvider.GetRequiredService<IGenericRepository<TEntity>>();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
