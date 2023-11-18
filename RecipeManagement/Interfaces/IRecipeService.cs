using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface IRecipeService
    {

        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        Task<RecipeDto> CreateRecipeAsync(int userId, RecipeDto recipeDto);
        Task<RecipeDto> GetRecipeByIdAsync(int recipeId);
        Task<RecipeDto> GetRecipeByTitleAsync(string recipeTitle);
        Task<IEnumerable<CategoryDto>> GetRecipesByCategoryName(string categoryName);
        Task UpdateRecipeAsync(int userId, int recipeId, RecipeDto recipeDto);
        Task<bool> DeleteRecipeAsync(int userId, int recipeId);

    }
}
