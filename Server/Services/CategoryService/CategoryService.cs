namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext Db;
        public CategoryService(DataContext db)
        {
            Db = db;
        }
        public async Task<ServiceResponse<List<Category>>> GetAll()
        {
            var result = new ServiceResponse<List<Category>>
            {
                Data = await Db.Categories.Include(c => c.Products).ToListAsync(),
                Success = true,
            };
            return result;
        }

        public async Task<ServiceResponse<Category>> GetById(int id)
        {
            var result = new ServiceResponse<Category>
            {
                Data = await Db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id),
                Success = true,
            };
            if(result.Data == null)
            {
                result.Success = false;
                result.Message = "Category was not found";
            }
            return result;

        }
    }
}
