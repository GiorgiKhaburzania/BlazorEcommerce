namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        public Task<ServiceResponse<Cart>> GetCart(int id);
        public Task<ServiceResponse<bool>> AddToCart(int cartId, int productId);
        public Task<ServiceResponse<bool>> RemoveFromCart(int cartId, int productId);
    }
}
