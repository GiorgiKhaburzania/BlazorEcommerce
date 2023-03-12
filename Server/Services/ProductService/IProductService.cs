namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        public Task<ServiceResponse<List<Product>>> GetAll();
        public Task<ServiceResponse<Product>> GetProduct(int id);
        public Task<ServiceResponse<Product>> EditProduct(Product product);
        public Task<ServiceResponse<Product>> DeleteProduct(int id);
        public Task<ServiceResponse<Product>> AddProduct(Product product);

    }
}
