using RecipeManagement.DTO;

namespace RecipeManagement.Interfaces
{
    public interface ISearchService
    {
        public Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string title);
    }
}
