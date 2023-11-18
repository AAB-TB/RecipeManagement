using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task UpdateCategoryAsync(int categoryId, CategoryDto categoryDto);
        Task DeleteCategoryAsync(int categoryId);

    }
}
