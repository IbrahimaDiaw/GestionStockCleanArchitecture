using GestionStock.Application.DTOs.Category;
using GestionStock.Infrastructure.Services.Interfaces;
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
        public async Task<ActionResult<CategoryOutputDto>> Createcategory(CategoryCreateDto input)
        {
            CategoryOutputDto output = await _categoryService.CreateAsync(input);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-category-id/{Id:guid}")]
        public async Task<ActionResult<CategoryOutputDto>> GetCateogryById(Guid Id)
        {
            return Ok(await _categoryService.GetIdAsync(Id));
        }
        [HttpGet]
        [Route("get-all-categories")]
        public async Task<ActionResult<List<CategoryOutputDto>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpPut]
        [Route("update-category/{Id:guid}")]
        public async Task<ActionResult<CategoryOutputDto>> UpdateAsync(Guid Id, CategoryUpdateDto updateDto)
        {
            CategoryOutputDto result = await _categoryService.UpdateAsync(Id, updateDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-category/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            await _categoryService.DeleteAsync(Id);
            return Ok(true);
        }
    }
}
