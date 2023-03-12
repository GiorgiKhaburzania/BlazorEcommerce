using BlazorEcommerce.Server.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _category { get; }

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAll()
        {
            return Ok(await _category.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ServiceResponse<Category>>> GetById(int id)
        {
            return Ok(await _category.GetById(id));
        }
    }
}
