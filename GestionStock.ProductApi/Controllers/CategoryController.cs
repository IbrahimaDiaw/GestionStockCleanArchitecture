using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GestionStock.ProductApi.Command.Category.CategoryCommand;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("create-category")]
        public async Task<ActionResult<CategoryResponse>> Createcategory(CategoryCreateRequest input)
        {
            var result = new CreateCategoryCommand(input);
            CategoryResponse output = await _mediator.Send(result);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-category-id/{Id:guid}")]
        public async Task<ActionResult<CategoryResponse>> GetCateogryById(Guid Id)
        {
            var brandCommand = new GetCategoryCommand(Id);
            return Ok(await _mediator.Send(brandCommand));
        }
        [HttpGet]
        [Route("get-all-categories")]
        public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
        {
            var brandCommand = new GetAllCategoryCommand();
            return Ok(await _mediator.Send(brandCommand));
        }
        [HttpPut]
        [Route("update-category/{Id:guid}")]
        public async Task<ActionResult<CategoryResponse>> UpdateAsync(Guid Id, CategoryUpdateRequest updateRequest)
        {
            var brandCommand = new UpdateCategoryCommand(Id, updateRequest);
            CategoryResponse result = await _mediator.Send(brandCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-category/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var brandCommand = new DeleteCommand(Id);
            return Ok(await _mediator.Send(brandCommand));
        }
    }
}
