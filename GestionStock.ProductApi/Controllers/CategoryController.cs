using GestionStock.Infrastructure.Services.Interfaces;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        [Route("create-category")]
        public async Task<ActionResult<CategoryResponse>> Createcategory(CategoryCreateRequest input)
        {
            CategoryResponse output = await _categoryService.CreateAsync(input);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-category-id/{Id:guid}")]
        public async Task<ActionResult<CategoryResponse>> GetCateogryById(Guid Id)
        {
            return Ok(await _categoryService.GetIdAsync(Id));
        }
        [HttpGet]
        [Route("get-all-categories")]
        public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpPut]
        [Route("update-category/{Id:guid}")]
        public async Task<ActionResult<CategoryResponse>> UpdateAsync(Guid Id, CategoryUpdateRequest updateRequest)
        {
            CategoryResponse result = await _categoryService.UpdateAsync(Id, updateRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-category/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            _categoryService.DeleteAsync(Id);
            return Ok(true);
        }
    }
}
