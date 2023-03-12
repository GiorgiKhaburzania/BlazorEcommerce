using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        public List<Product>? productList { get; set; }
        public Task GetAll();
        public Task<ServiceResponse<Product>> GetById(int id);
        public Task EditProduct(Product product);
        public Task DeleteProduct(int id);
        public Task AddProduct(Product product);
    }
}
