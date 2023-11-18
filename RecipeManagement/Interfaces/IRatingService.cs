using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> CreateRateRecipeAsync(int userId, int recipeId, RatingDto ratingDto);
        Task<IEnumerable<RatingDto>> GetRatingsByRecipeIdAsync(int recipeId);
        Task<IEnumerable<RatingDto>> GetRecipesByRatingValueAsync(int ratingValue);
        Task UpdateRatingAsync(int userId, int ratingId, RatingDto ratingDTO);
        Task DeleteRatingAsync(int userId, int ratingId);
    }
}
