using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GestionStock.ProductApi.Command.Product.ProductCommand;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<ActionResult<ProductResponse>> CreateProduct(ProductCreateRequest input)
        {
            var result = new CreateProductCommand(input);
            ProductResponse output = await _mediator.Send(result);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-product-id/{Id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(Guid Id)
        {
            var brandCommand = new GetProductCommand(Id);
            return Ok(await _mediator.Send(brandCommand));
        }
        [HttpGet]
        [Route("get-all-products")]
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            var brandCommand = new GetAllProductCommand();
            return Ok(await _mediator.Send(brandCommand));
        }
        [HttpPut]
        [Route("update-product/{Id:guid}")]
        public async Task<ActionResult<ProductResponse>> UpdateAsync(Guid Id, ProductUpdateRequest updateRequest)
        {
            var brandCommand = new UpdateProductCommand(Id, updateRequest);
            ProductResponse result = await _mediator.Send(brandCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-product/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var brandCommand = new DeleteCommand(Id);
            return Ok(await _mediator.Send(brandCommand));
        }
    }
}
