using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        public Cart? Cart { get; set; }
        public int CartCount { get; set; }

        private readonly HttpClient _http;
        private NavigationManager _nav;
        public CartService(HttpClient http, NavigationManager nav)
        {
            _http = http;
            _nav = nav;
        }

        public async Task GetCart(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Cart>>($"api/Cart/GetCart?id={id}");
            Cart = result?.Data;
            CartCount = result?.Data.Products.Count ?? 0;
        }

        public async Task AddToCart(int cartId, int productId)
        {
            await _http.PostAsJsonAsync<ServiceResponse<bool>>($"api/Cart/AddToCart?cartId={cartId}&productId={productId}", null);
            CartCount++;
            _nav.NavigateTo("Cart");
        }

        

        public async Task RemoveFromCart(int cartId, int productId)
        {
            var cartItem = Cart.Products.Find(p => p.Id == productId);
            if(cartItem != null)
            {
                await _http.DeleteAsync($"api/Cart/Remove?cartId={cartId}&productId={productId}");
                CartCount--;
                Cart.Products.Remove(cartItem);
            }
        }
    }
}
