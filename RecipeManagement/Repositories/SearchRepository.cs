using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Repositories
{
    public class SearchRepository : ISearchService
    {
        private readonly DapperContext _context;
        public SearchRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}
