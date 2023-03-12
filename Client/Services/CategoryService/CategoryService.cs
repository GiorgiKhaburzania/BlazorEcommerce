namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        public List<Category>? CategoryList { get; set; }

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetAll()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category/GetAll");
            CategoryList = result!.Data;
        }

        public async Task<ServiceResponse<Category>> GetById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Category>>($"api/Category/GetById?id={id}");

            return result!;
        }
    }
}
