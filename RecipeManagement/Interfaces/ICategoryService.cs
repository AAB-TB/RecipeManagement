using RecipeManagement.DTO;

namespace RecipeManagement.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
