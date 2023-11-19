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

        
        public async Task DeleteRatingAsync(int userId, int ratingId)
        {
            try
            {
                // Define your SQL query to delete a rating by ID and user ID
                var query = "DELETE FROM Ratings WHERE RatingID = @RatingId AND RatingUserID = @UserId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query
                    await connection.ExecuteAsync(query, new { RatingId = ratingId, UserId = userId });
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<CreateRatingDto> RateRecipeAsync(int userId, int recipeId, CreateRatingDto createRatingDto)
        {
            try
            {
                // Check if the user is the owner of the recipe
                const string checkOwnershipSql = "SELECT TOP 1 1 FROM Recipes WHERE RecipeID = @RecipeId AND UserID = @UserId";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    var isUserOwner = await connection.ExecuteScalarAsync<int>(
                        checkOwnershipSql,
                        new { RecipeId = recipeId, UserId = userId }
                    );

                    if (isUserOwner == 1)
                    {
                        // If the user is the owner of the recipe, throw an exception or handle accordingly
                        throw new UnauthorizedAccessException("User cannot rate their own recipe.");
                    }

                    // If the user is not the owner, proceed with the rating
                    const string rateRecipeSql = @"
            INSERT INTO Ratings (RatedRecipeID, RatingUserID, RatingValue, RecipeCreatorID)
            VALUES (@RecipeId, @RatingUserId, @RatingValue, @UserId);
            SELECT CAST(SCOPE_IDENTITY() as int);
            ";

                    // Execute the rating query
                    var ratingId = await connection.QueryFirstOrDefaultAsync<int>(
                        rateRecipeSql,
                        new
                        {
                            RecipeId = recipeId,
                            RatingUserId = userId,
                            RatingValue = createRatingDto.RatingValue,
                            UserId = userId // Assuming RecipeCreatorID is the same as the user who rates
                        }
                    );

                    // Set the generated rating ID in the DTO
                    createRatingDto.RatingID = ratingId;

                    return createRatingDto;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }
        private async Task<RecipeDto> GetRecipeCreatorInfoAsync(int recipeId)
        {
            var query = @"
    SELECT r.*, u.UserID as CreatorUserId
    FROM Recipes r
    JOIN Users u ON r.UserID = u.UserID
    WHERE r.RecipeID = @RecipeId;";

            using (var connection = _dapperConnection.GetDbConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<RecipeDto>(query, new { RecipeId = recipeId });
            }
        }
        private async Task<RecipeDto> GetRecipeCreatorIdAsync(int recipeId)
        {
            var query = @"
            SELECT r.*, u.UserID as CreatorUserId
            FROM Recipes r
            JOIN Users u ON r.UserID = u.UserID
            WHERE r.RecipeID = @RecipeId;";

            using (var connection = _dapperConnection.GetDbConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<RecipeDto>(query, new { RecipeId = recipeId });
            }
        }
        public async Task UpdateRatingAsync(int userId, int recipeId, RatingDto ratingDto)
        {
            try
            {
                // Map the DTO to the entity
                var ratingEntity = _mapper.Map<Rating>(ratingDto);

                // Set the necessary IDs based on the provided parameters
                ratingEntity.RatingUserID = userId;
                ratingEntity.RatedRecipeID = recipeId; 

                // Define your SQL query to update a rating by ID and user ID
                var query = @"
            UPDATE Ratings
            SET RatingValue = @RatingValue, RatedRecipeID = @RatedRecipeID, RatingUserID = @RatingUserID
            WHERE RatingID = @RatingId AND RatingUserID = @UserId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return whether any rows were affected
                    var affectedRows = await connection.ExecuteAsync(query, ratingEntity);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }
    }
}
