using GestionStock.Infrastructure.Services.Interfaces;
using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GestionStock.ProductApi.Command.Brand.BrandCommand;

namespace GestionStock.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMediator _mediator;

        public BrandController(IBrandService brandService , IMediator mediator)
        {
            _brandService = brandService;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("create-brand")]
        public async Task<ActionResult<BrandResponse>> CreateBrand(BrandCreateRequest input) 
        {
            var result = new CreateBrandCommand(input);
            BrandResponse output = await _mediator.Send(result);
            return Ok(output);
        }

        [HttpGet]
        [Route("get-brand-id/{Id:guid}")]
        public async Task<ActionResult<BrandResponse>> GetBrandById(Guid Id)
        {
            var brandCommand = new GetBrandCommand(Id);
            return Ok(await _mediator.Send(brandCommand));
        }
        [HttpGet]
        [Route("get-all-brands")]
        public async Task<ActionResult<List<BrandResponse>>> GetAllBrands()
        {
            return Ok(await _brandService.GetAllAsync());
        }
        [HttpGet]
        [Route("get-all-brands-with-products")]
        public async Task<ActionResult<List<BrandResponse>>> GetAllWithProducts()
        {
            return Ok(await _brandService.GetAllWithProductsAsync());
        }
        [HttpPut]
        [Route("update-brand/{Id:guid}")]
        public async Task<ActionResult<BrandResponse>> UpdateAsync(Guid Id, BrandUpdateRequest brandUpdateRequest)
        {
            var brandCommand = new UpdateBrandCommand(Id, brandUpdateRequest);
            BrandResponse result = await _mediator.Send(brandCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-brand/{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
             _brandService.DeleteAsync(Id);
            return Ok(true);
        }
    }
}
