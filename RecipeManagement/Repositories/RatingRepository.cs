using AutoMapper;
using Dapper;
using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;
using RecipeManagement.Model;

namespace RecipeManagement.Repositories
{
    public class RatingRepository : IRatingService
    {
        private readonly DapperConnection _dapperConnection;
        private readonly IMapper _mapper;

        public RatingRepository(DapperConnection dapperConnection, IMapper mapper)
        {
            _dapperConnection = dapperConnection;
            _mapper = mapper;
        }

        public async Task<RatingDto> CreateRateRecipeAsync(int userId, int recipeId, RatingDto ratingDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRatingAsync(int userId, int ratingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByRecipeIdAsync(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RatingDto>> GetRecipesByRatingValueAsync(int ratingValue)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRatingAsync(int userId, int ratingId, RatingDto ratingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
