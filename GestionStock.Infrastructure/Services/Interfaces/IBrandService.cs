using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface IBrandService : IServiceBase<BrandResponse, BrandCreateRequest, BrandUpdateRequest>
    {
        Task<List<BrandResponse>> GetAllWithProductsAsync();
    }
}
