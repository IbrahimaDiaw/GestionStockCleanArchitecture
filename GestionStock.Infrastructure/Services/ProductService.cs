using GestionStock.Application.DTOs.Product;
using GestionStock.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductOutputDto> CreateAsync(ProductCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductOutputDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductOutputDto> GetIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductOutputDto> UpdateAsync(Guid Id, ProductUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
