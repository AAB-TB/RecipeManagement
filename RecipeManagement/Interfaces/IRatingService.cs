using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface IRatingService
    {

        Task<CreateRatingDto> RateRecipeAsync(int userId, int recipeId, CreateRatingDto createRatingDto);
        Task UpdateRatingAsync(int userId, int recipeId, RatingDto ratingDTO);
        Task DeleteRatingAsync(int userId, int ratingId);
    }
}
