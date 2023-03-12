using BlazorEcommerce.Server.Migrations;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext Db;
        public CartService(DataContext db)
        {
            Db = db;
        }
        public async Task<ServiceResponse<Cart>> GetCart(int id)
        {
            var result = new ServiceResponse<Cart>
            {
                Data = await Db.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id),
                Success = true
            };
            if (result.Data == null)
            {
                result.Success = false;
                result.Message = "Category was not found";
            }
            return result;
        }
        public async Task<ServiceResponse<bool>> AddToCart(int cartId, int productId)
        {
            var foundCart = await Db.Carts.FindAsync(cartId);
            var foundProduct = await Db.Products.FindAsync(productId);
            if(foundCart != null && foundProduct != null)
            {
                foundProduct.CartId = cartId;
                foundCart.TotalPrice += foundProduct.Price;
                await Db.SaveChangesAsync();
                return new ServiceResponse<bool>{ Success = true };
            }
            else
            {
                return new ServiceResponse<bool> { Success = false };
            }
        }
        public async Task<ServiceResponse<bool>> RemoveFromCart(int cartId, int productId)
        {
            var result = new ServiceResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "Item was not found in the cart"
            };
            var product = await Db.Products.FindAsync(productId);
            var cart = await Db.Carts.FindAsync(cartId);
                
                if(product != null && cart != null)
                {
                    result.Success = true;
                    result.Message = "";
                    result.Data = true;
                    product.CartId = null;
                    cart.TotalPrice -= product.Price;
                    await Db.SaveChangesAsync();
                }
            
            return result;
        }
    }
}
