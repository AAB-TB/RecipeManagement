using AutoMapper;
using Dapper;
using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;
using RecipeManagement.Model;

namespace RecipeManagement.Repositories
{
    public class RecipeRepository : IRecipeService
    {
        private readonly DapperConnection _dapperConnection;
        private readonly IMapper _mapper;

        public RecipeRepository(DapperConnection dapperConnection, IMapper mapper)
        {
            _dapperConnection = dapperConnection;
            _mapper = mapper;
        }

        public async Task<RecipeDto> CreateRecipeAsync(int userId, RecipeDto recipeDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteRecipeAsync(int userId, int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeDto> GetRecipeByIdAsync(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeDto> GetRecipeByTitleAsync(string recipeTitle)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetRecipesByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipeAsync(int userId, int recipeId, RecipeDto recipeDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipeAsync(int userId, int recipeId, UpdateRecipeDto updateRecipeDto)
        {
            throw new NotImplementedException();
        }
    }
}
