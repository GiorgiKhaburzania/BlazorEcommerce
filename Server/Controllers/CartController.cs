using BlazorEcommerce.Server.Services.CartService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService _cart)
        {
            _cartService = _cart;
        }

        [HttpGet("GetCart")]
        public async Task<ActionResult<ServiceResponse<Cart>>> GetCart(int id)
        {
            return await _cartService.GetCart(id);
        }

        [HttpPost("AddToCart")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(int cartId, int productId)
        {
            return await _cartService.AddToCart(cartId, productId);
        }

        [HttpDelete("Remove")]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(int cartId, int productId)
        {
            return await _cartService.RemoveFromCart(cartId, productId);
        }

    }
}
