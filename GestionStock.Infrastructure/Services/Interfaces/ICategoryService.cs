using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface ICategoryService : IServiceBase<CategoryResponse, CategoryCreateRequest, CategoryUpdateRequest>
    {
    }
}
