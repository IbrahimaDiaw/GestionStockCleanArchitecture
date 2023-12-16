using GestionStock.Infrastructure.Services.Interfaces;
using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<ActionResult<ProductResponse>> CreateProduct(ProductCreateRequest input)
        {
            ProductResponse output = await _productService.CreateAsync(input);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-product-id/{Id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(Guid Id)
        {
            return Ok(await _productService.GetIdAsync(Id));
        }
        [HttpGet]
        [Route("get-all-products")]
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpPut]
        [Route("update-product/{Id:guid}")]
        public async Task<ActionResult<ProductResponse>> UpdateAsync(Guid Id, ProductUpdateRequest updateRequest)
        {
            ProductResponse result = await _productService.UpdateAsync(Id, updateRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-product/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            _productService.DeleteAsync(Id);
            return Ok(true);
        }
    }
}
