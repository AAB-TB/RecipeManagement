using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Repositories
{
    public class CategoryRepository : ICategoryService
    {
        private readonly DapperContext _context;
        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
