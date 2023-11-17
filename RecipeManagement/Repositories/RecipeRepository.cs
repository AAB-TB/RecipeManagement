using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Repositories
{
    public class RecipeRepository : IRecipeService
    {
        private readonly DapperContext _context;
        public RecipeRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<int> CreateRecipeAsync(int userId, RecipeDto recipeDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecipeAsync(int userId, int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRecipeAsync(int userId, int recipeId, RecipeDto recipeDto)
        {
            throw new NotImplementedException();
        }
    }
}
