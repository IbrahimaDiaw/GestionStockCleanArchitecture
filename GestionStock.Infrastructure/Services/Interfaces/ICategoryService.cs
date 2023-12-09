using GestionStock.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface ICategoryService : IServiceBase<CategoryOutputDto, CategoryCreateDto, CategoryUpdateDto>
    {
    }
}
