using GestionStock.Application.DTOs.Category;
using GestionStock.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryOutputDto> CreateAsync(CategoryCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryOutputDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryOutputDto> GetIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryOutputDto> UpdateAsync(Guid Id, CategoryUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
