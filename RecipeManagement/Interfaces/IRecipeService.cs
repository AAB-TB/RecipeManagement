using RecipeManagement.DTO;

namespace RecipeManagement.Interfaces
{
    public interface IRecipeService
    {
        public Task<int> CreateRecipeAsync(int userId, RecipeDto recipeDto);
        public Task<bool> UpdateRecipeAsync(int userId, int recipeId, RecipeDto recipeDto);
        public Task<bool> DeleteRecipeAsync(int userId, int recipeId);
        public Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string title);
    }
}
