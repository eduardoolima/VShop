using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var categoriesDto = await _ProductService.GetProducts();

            if (categoriesDto is null)
            {
                return NotFound("Products not found");
            }
            return Ok(categoriesDto);
        }        

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(int id)
        {
            var categoriesDto = await _ProductService.GetProductById(id);

            if (categoriesDto is null)
            {
                return NotFound("Products not found");
            }
            return Ok(categoriesDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto is null)
            {
                return BadRequest("Invalid Data");
            }

            await _ProductService.AddProduct(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id || productDto is null)
            {
                return BadRequest();
            }

            await _ProductService.UpdateProduct(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _ProductService.GetProductById(id);
            if (productDto is null)
            {
                return NotFound("Product not found");
            }

            await _ProductService.RemoveProduct(id);
            return Ok(productDto);
        }
    }
}
