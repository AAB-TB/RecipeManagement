using RecipeManagement.DTO;

namespace RecipeManagement.Interfaces
{
    public interface IRatingService
    {
        public Task<bool> RateRecipeAsync(int userId, int recipeId, int rating);
        public Task<IEnumerable<RatingDto>> GetRatingsAsync(int recipeId);
    }
}
