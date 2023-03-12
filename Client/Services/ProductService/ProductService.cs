using BlazorEcommerce.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public List<Product>? productList { get; set; }


        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetAll()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/GetAll");
            if (result != null && result.Data != null)
            {
                productList = result.Data;
            }
        }

        public async Task<ServiceResponse<Product>> GetById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/GetById?id={id}");
            return result!;
        }

        public async Task AddProduct(Product product)
        {
            await _http.PostAsJsonAsync($"api/Product/Add", product);
        }

        public async Task EditProduct(Product product)
        {
            await _http.PutAsJsonAsync($"api/Product/Edit", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _http.DeleteAsync($"api/Product/Delete?id={id}");
        }
    }
}
