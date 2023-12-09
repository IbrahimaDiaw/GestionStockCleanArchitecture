using GestionStock.Application.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface IBrandService : IServiceBase<BrandOutputDto, BrandCreateDto, BrandUpdateDto>
    {
        Task<List<BrandOutputDto>> GetAllWithProductsAsync();
    }
}
