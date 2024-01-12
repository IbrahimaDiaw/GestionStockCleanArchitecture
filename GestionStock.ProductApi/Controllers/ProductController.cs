using GestionStock.Shared.Common;
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
            return Ok(await Result<ProductResponse>.SuccessAsync(output));
        }

        [HttpGet]
        [Route("get-product-id/{Id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(Guid Id)
        {
            var productCommand = new GetProductCommand(Id);
            var result = await _mediator.Send(productCommand);
            return Ok(await Result<ProductResponse>.SuccessAsync(result));
        }
        [HttpGet]
        [Route("get-all-products")]
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            var productCommand = new GetAllProductCommand();
            var result = await _mediator.Send(productCommand);
            return Ok(await Result<List<ProductResponse>>.SuccessAsync(result));
        }
        [HttpPut]
        [Route("update-product/{Id:guid}")]
        public async Task<ActionResult<ProductResponse>> UpdateAsync(Guid Id, ProductUpdateRequest updateRequest)
        {
            var productCommand = new UpdateProductCommand(Id, updateRequest);
            ProductResponse result = await _mediator.Send(productCommand);
            return Ok(await Result<ProductResponse>.SuccessAsync(result));
        }

        [HttpDelete]
        [Route("delete-product/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var productCommand = new DeleteCommand(Id);
            var result = await _mediator.Send(productCommand);
            return Ok(await Result<bool>.SuccessAsync(result));
        }
    }
}
