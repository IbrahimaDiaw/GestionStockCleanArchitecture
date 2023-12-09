using GestionStock.Application.DTOs.Product;
using GestionStock.Infrastructure.Services.Interfaces;
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
        public async Task<ActionResult<ProductOutputDto>> CreateProduct(ProductCreateDto input)
        {
            ProductOutputDto output = await _productService.CreateAsync(input);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-product-id/{Id:guid}")]
        public async Task<ActionResult<ProductOutputDto>> GetProductById(Guid Id)
        {
            return Ok(await _productService.GetIdAsync(Id));
        }
        [HttpGet]
        [Route("get-all-products")]
        public async Task<ActionResult<List<ProductOutputDto>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpPut]
        [Route("update-product/{Id:guid}")]
        public async Task<ActionResult<ProductOutputDto>> UpdateAsync(Guid Id, ProductUpdateDto updateDto)
        {
            ProductOutputDto result = await _productService.UpdateAsync(Id, updateDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-product/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            await _productService.DeleteAsync(Id);
            return Ok(true);
        }
    }
}
