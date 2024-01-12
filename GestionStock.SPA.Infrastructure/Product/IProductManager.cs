using GestionStock.Shared.Common;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Product
{
    public interface IProductManager
    {
        Task<IResult<bool>> SaveProductAsync(ProductCreateRequest request);
        Task<IResult<List<ProductResponse>>> GetAllProductsAsync();
        Task<IResult<ProductResponse>> UpdateProductAsync(Guid Id, ProductUpdateRequest request);
        Task<IResult<bool>> DeleteProductAsync(Guid Id);
    }
}
