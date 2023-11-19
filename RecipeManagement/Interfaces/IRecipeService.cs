using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface IRecipeService
    {

        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        Task<IEnumerable<RecipeDto>> GetRecipesByUsernameAsync(string username);
        Task<CreateRecipeDto> CreateRecipeAsync(int userId, int categoryId, CreateRecipeDto createRecipeDto);
        Task<RecipeDto> GetRecipeByIdAsync(int recipeId);
        Task<RecipeDto> GetRecipeByTitleAsync(string recipeTitle);
        Task<IEnumerable<RecipeDto>> GetRecipesByCategoryName(string categoryName);
        Task UpdateRecipeAsync(int userId, int recipeId, UpdateRecipeDto updateRecipeDto);
        Task DeleteRecipeAsync(int userId, int recipeId);

    }
}