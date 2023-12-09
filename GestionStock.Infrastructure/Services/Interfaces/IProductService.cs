using GestionStock.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface IProductService : IServiceBase<ProductOutputDto, ProductCreateDto, ProductUpdateDto>
    {
    }
}
