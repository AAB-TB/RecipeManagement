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

        public async Task<CreateRecipeDto> CreateRecipeAsync(int userId, int categoryId, CreateRecipeDto createRecipeDto)
        {
            try
            {
                // Map the DTO to the entity
                var recipeEntity = _mapper.Map<Recipe>(createRecipeDto);

                // Set the UserID and CategoryID based on the provided parameters
                recipeEntity.UserID = userId;
                recipeEntity.CategoryID = categoryId;

                // Define your SQL query
                var query = @"
            INSERT INTO Recipes (UserID, Title, Description, Ingredients, CategoryID, ImagePath)
            VALUES (@UserID, @Title, @Description, @Ingredients, @CategoryID, @ImagePath);
            SELECT CAST(SCOPE_IDENTITY() as int);";
                Console.WriteLine($"SQL Query: {query}");
                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and retrieve the generated ID
                    var recipeId = await connection.QuerySingleAsync<int>(query, recipeEntity);


                    return createRecipeDto;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task DeleteRecipeAsync(int userId, int recipeId)
        {
            try
            {
                // Define your SQL query
                var query = "DELETE FROM Recipes WHERE UserID = @UserId AND RecipeID = @RecipeId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query
                    await connection.ExecuteAsync(query, new { UserId = userId, RecipeId = recipeId });
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            try
            {
                // Define your SQL query
                var query = @"
            SELECT r.*, u.*, c.*, ra.*
            FROM Recipes r
            INNER JOIN Users u ON r.UserID = u.UserID
            INNER JOIN Categories c ON r.CategoryID = c.CategoryID
            LEFT JOIN Ratings ra ON r.RecipeID = ra.RatedRecipeID;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the results
                    var recipes = await connection.QueryAsync<RecipeDto, UserProfileDto, CreateCategoryDto, RaterProfileDto, RecipeDto>(
                        query,
                        (recipe, user, category, rating) =>
                        {
                            recipe.User = user;
                            recipe.Category = category;
                            if (rating != null)
                            {
                                recipe.Ratings = rating ;
                            }
                            return recipe;
                        },
                        splitOn: "UserID,CategoryID,RatingID"
                    );
                    return recipes;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<RecipeDto> GetRecipeByIdAsync(int recipeId)
        {
            try
            {
                // Define your SQL query with an inner join
                var query = @"
    SELECT r.*, u.*, c.*
    FROM Recipes r
    INNER JOIN Users u ON r.UserID = u.UserID
    INNER JOIN Categories c ON r.CategoryID = c.CategoryID
    WHERE r.RecipeID = @RecipeId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the result
                    var recipes = await connection.QueryAsync<RecipeDto, UserProfileDto, CreateCategoryDto, RecipeDto>(
                        query,
                        (recipe, user, category) =>
                        {
                            recipe.User = user;
                            recipe.Category = category;
                            return recipe;
                        },
                        new { RecipeId = recipeId },
                        splitOn: "UserID,CategoryID"
                    );

                    // Since you're fetching a recipe by its ID, you may want to use FirstOrDefault
                    return recipes.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }
        public async Task<RecipeDto> GetRecipeByTitleAsync(string recipeTitle)
        {
            try
            {
                // Define your SQL query to get the recipe by title and join with Users and Categories tables
                var query = @"
            SELECT r.*, u.*, c.*
            FROM Recipes r
            INNER JOIN Users u ON r.UserID = u.UserID
            INNER JOIN Categories c ON r.CategoryID = c.CategoryID
            WHERE r.Title = @RecipeTitle;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the result
                    var recipe = await connection.QueryAsync<RecipeDto, UserProfileDto, CreateCategoryDto, RecipeDto>(
                        query,
                        (recipe, user, category) =>
                        {
                            recipe.User = user;
                            recipe.Category = category;
                            return recipe;
                        },
                        new { RecipeTitle = recipeTitle },
                        splitOn: "UserID,CategoryID"
                    );

                    return recipe.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }


        public async Task<IEnumerable<RecipeDto>> GetRecipesByCategoryName(string categoryName)
        {
            try
            {
                // Define your SQL query to get the Category by name and join with Recipes and Users tables
                var query = @"
            SELECT r.*, u.*, c.*
            FROM Recipes r
            INNER JOIN Users u ON r.UserID = u.UserID
            INNER JOIN Categories c ON r.CategoryID = c.CategoryID
            WHERE c.CategoryName = @CategoryName;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and retrieve the results
                    var recipes = await connection.QueryAsync<RecipeDto, UserProfileDto, CreateCategoryDto, RecipeDto>(
                        query,
                        (recipe, user, category) =>
                        {
                            recipe.User = user;
                            recipe.Category = category;
                            return recipe;
                        },
                        new { CategoryName = categoryName },
                        splitOn: "UserID,CategoryID"
                    );

                    return recipes;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesByUsernameAsync(string username)
        {
            try
            {
                // Define your SQL query
                var query = @"
            SELECT r.*, u.*, c.*
            FROM Recipes r
            INNER JOIN Users u ON r.UserID = u.UserID
            INNER JOIN Categories c ON r.CategoryID = c.CategoryID
            WHERE u.Username = @Username;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the results
                    var recipes = await connection.QueryAsync<RecipeDto, UserProfileDto, CreateCategoryDto, RecipeDto>(
                        query,
                        (recipe, user, category) =>
                        {
                            recipe.User = user;
                            recipe.Category = category;
                            return recipe;
                        },
                        new { Username = username },
                        splitOn: "UserID,CategoryID"
                    );

                    return recipes;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task UpdateRecipeAsync(int userId, int recipeId, UpdateRecipeDto updateRecipeDto)
        {
            try
            {
                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Fetch the CategoryID based on the new category name
                    var newCategoryQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName;";
                    var newCategoryId = await connection.QueryFirstOrDefaultAsync<int>(newCategoryQuery, new { CategoryName = updateRecipeDto.Category.CategoryName });

                    if (newCategoryId == default)
                    {
                        // Handle the case where the new category doesn't exist
                        // You can throw an exception, log a message, or handle it based on your requirements
                        throw new InvalidOperationException("The specified category does not exist.");
                    }

                    // Map the DTO to the entity
                    var recipeEntity = _mapper.Map<Recipe>(updateRecipeDto);

                    // Set the UserID and RecipeID based on the provided parameters
                    recipeEntity.UserID = userId;
                    recipeEntity.RecipeID = recipeId;

                    // Set the new CategoryID
                    recipeEntity.CategoryID = newCategoryId;

                    // Define your SQL query
                    var query = @"
                UPDATE Recipes
                SET Title = @Title, Description = @Description, Ingredients = @Ingredients, ImagePath = @ImagePath, CategoryID = @CategoryID
                WHERE UserID = @UserID AND RecipeID = @RecipeID;";

                    // Execute the query and return whether any rows were affected
                    var affectedRows = await connection.ExecuteAsync(query, recipeEntity);
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