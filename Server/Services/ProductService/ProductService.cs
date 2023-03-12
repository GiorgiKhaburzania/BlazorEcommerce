using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        public ProductService(DataContext db)
        {
            Db = db;
        }
        public DataContext Db { get; }

        public async Task<ServiceResponse<List<Product>>> GetAll()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await Db.Products.ToListAsync(),
                Success = true,
                Message = "Ok"
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = new ServiceResponse<Product>
            {
                Data = await Db.Products.FirstOrDefaultAsync(p => p.Id == id),
                Success = true,
                Message = $"Got product with id: {id}"
            };
            if(response.Data == null)
            {
                response.Success = false;
                response.Message = "Product was not found";
            }
            return response;
        }

        public async Task<ServiceResponse<Product>> EditProduct(Product product)
        {
            var foundProduct = await Db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            var response = new ServiceResponse<Product>
            {
                Data = foundProduct,
                Success = true,
                Message = $"Got product with id: {foundProduct?.Id}"
            };

            if (foundProduct == null)
            {
                response.Success = false;
                response.Message = "Product was not found";
            }
            else
            {
                foundProduct.Title = product.Title;
                foundProduct.Description = product.Description;
                foundProduct.ImageUrl = product.ImageUrl;
                foundProduct.Price = product.Price;
                foundProduct.CategoryId = product.CategoryId;

                await Db.SaveChangesAsync();
            }
            return response;
        }

        public async Task<ServiceResponse<Product>> DeleteProduct(int id)
        {
            var foundProduct = await Db.Products.FirstOrDefaultAsync(p => p.Id == id);
            var response = new ServiceResponse<Product>
            {
                Data = foundProduct,
                Success = true,
                Message = $"Got product with id: {foundProduct?.Id}"
            };

            if (foundProduct == null)
            {
                response.Success = false;
                response.Message = "Product was not found";
            }
            else
            {
                Db.Products.Remove(foundProduct);
                await Db.SaveChangesAsync();
            }
            return response;
        }

        public async Task<ServiceResponse<Product>> AddProduct(Product product)
        {
            var response = new ServiceResponse<Product>
            {
                Data = product,
                Success = true,
                Message = "Added"
            };

            Db.Products.Add(product);
            await Db.SaveChangesAsync();
            return response;
        }
    }
}
