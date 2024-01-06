using GestionStock.Shared.Common;
using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Brand
{
    public interface IBrandManager
    {
        Task<IResult<bool>> SaveBrandAsync(BrandCreateRequest request);
        Task<IResult<List<BrandResponse>>> GetAllBrandsAsync();
        Task<IResult<BrandResponse>> UpdateBrandAsync(Guid Id, BrandUpdateRequest request);
        Task<IResult<bool>> DeleteBrandAsync(Guid Id);
    }
}
