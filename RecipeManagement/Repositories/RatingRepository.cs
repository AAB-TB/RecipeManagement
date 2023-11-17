using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Repositories
{
    public class RatingRepository : IRatingService
    {
        private readonly DapperContext _context;
        public RatingRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<RatingDto>> GetRatingsAsync(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RateRecipeAsync(int userId, int recipeId, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
