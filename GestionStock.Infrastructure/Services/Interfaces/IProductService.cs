using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface IProductService : IServiceBase<ProductResponse, ProductCreateRequest, ProductUpdateRequest>
    {
    }
}
