namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        public Cart Cart { get; set; }
        public int CartCount { get; set; }
        public Task GetCart(int id);
        public Task AddToCart(int cartId, int productId);
        public Task RemoveFromCart(int cartId, int productId);
    }
}
