using BlazorEcommerce.Server.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService _product { get; }

        public ProductController(IProductService product)
        {
            _product = product;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAll()
        {
            return Ok(await _product.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetById(int id)
        {
            return Ok(await _product.GetProduct(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProduct(Product product)
        {
            return Ok(await _product.AddProduct(product));
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ServiceResponse<Product>>> EditProduct(Product product)
        {
            return Ok(await _product.EditProduct(product));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceResponse<Product>>> DeleteProduct(int id)
        {
            return Ok(await _product.DeleteProduct(id));
        }
    }
}
