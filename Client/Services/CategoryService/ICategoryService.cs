namespace BlazorEcommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        public List<Category> CategoryList { get; set; }
        public Task GetAll();
        public Task<ServiceResponse<Category>> GetById(int id);
    }
}
