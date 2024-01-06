using GestionStock.Shared.Common;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.SPA.Infrastructure.Category
{
    public interface ICategoryManager
    {
        Task<IResult<bool>> SaveCategoryAsync(CategoryCreateRequest request);
        Task<IResult<List<CategoryResponse>>> GetAllCategoriesAsync();
        Task<IResult<CategoryResponse>> UpdateCategoryAsync(Guid Id, CategoryUpdateRequest request);
        Task<IResult<bool>> DeleteCategoryAsync(Guid Id);
    }
}
