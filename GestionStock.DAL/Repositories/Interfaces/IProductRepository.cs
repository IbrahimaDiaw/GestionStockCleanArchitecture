using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetProduitsByIdCategory(Guid categoryId);
        Task<IEnumerable<ProductEntity>> GetProduitsByIdBrand(Guid bandId);
    }
}
