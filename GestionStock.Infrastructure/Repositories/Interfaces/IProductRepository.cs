using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
    }
}
