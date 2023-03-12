namespace BlazorEcommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<List<Category>>> GetAll();
        public Task<ServiceResponse<Category>> GetById(int id);
    }
}
