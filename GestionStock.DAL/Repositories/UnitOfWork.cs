using GestionStock.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public GestionStockDbContext _dbContext { get; set; }
        public UnitOfWork(GestionStockDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
