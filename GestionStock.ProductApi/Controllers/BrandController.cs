using GestionStock.Application.DTOs.Brand;
using GestionStock.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        [Route("create-brand")]
        public async Task<ActionResult<BrandOutputDto>> CreateBrand(BrandCreateDto input) 
        {
            BrandOutputDto output = await _brandService.CreateAsync(input);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-brand-id/{Id:guid}")]
        public async Task<ActionResult<BrandOutputDto>> GetProductById(Guid Id)
        {
            return Ok(await _brandService.GetIdAsync(Id));
        }
        [HttpGet]
        [Route("get-all-brands")]
        public async Task<ActionResult<List<BrandOutputDto>>> GetAllBrands()
        {
            return Ok(await _brandService.GetAllAsync());
        }
        [HttpGet]
        [Route("get-all-brands-with-products")]
        public async Task<ActionResult<List<BrandOutputDto>>> GetAllWithProducts()
        {
            return Ok(await _brandService.GetAllWithProductsAsync());
        }
        [HttpPut]
        [Route("update-brand/{Id:guid}")]
        public async Task<ActionResult<BrandOutputDto>> UpdateAsync(Guid Id, BrandUpdateDto brandUpdateDto)
        {
            BrandOutputDto result = await _brandService.UpdateAsync(Id, brandUpdateDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-brand/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            await _brandService.DeleteAsync(Id);
            return Ok(true);
        }
    }
}
