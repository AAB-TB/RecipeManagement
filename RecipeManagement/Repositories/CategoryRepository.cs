using AutoMapper;
using Dapper;
using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;
using RecipeManagement.Model;

namespace RecipeManagement.Repositories
{
    public class CategoryRepository : ICategoryService
    {
        private readonly DapperConnection _dapperConnection;
        private readonly IMapper _mapper;

        public CategoryRepository(DapperConnection dapperConnection, IMapper mapper)
        {
            _dapperConnection = dapperConnection;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            try
            {
                // Map the DTO to the entity
                var categoryEntity = _mapper.Map<Category>(categoryDto);

                // Define your SQL query
                var query = @"
                                INSERT INTO Categories (CategoryName)
                                VALUES (@CategoryName);
                                SELECT CAST(SCOPE_IDENTITY() as int);";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and retrieve the generated ID
                    var categoryId = await connection.QuerySingleAsync<int>(query, categoryEntity);

                    return categoryDto;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                // For now, rethrow the exception
                throw;
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            try
            {
                // Define your SQL query
                var query = "DELETE FROM Categories WHERE CategoryID = @CategoryId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query
                    await connection.ExecuteAsync(query, new { CategoryId = categoryId });
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                // For now, rethrow the exception
                throw;
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            try
            {
                // Define your SQL query
                var query = "SELECT * FROM Categories;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and retrieve the categories
                    var categories = await connection.QueryAsync<CategoryDto>(query);

                    return categories;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                // For now, rethrow the exception
                throw;
            }
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                // Define your SQL query with a parameter for categoryId
                var query = "SELECT * FROM Categories WHERE CategoryID = @CategoryId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and retrieve the category
                    var category = await connection.QueryFirstOrDefaultAsync<CategoryDto>(query, new { CategoryId = categoryId });

                    return category;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                // For now, rethrow the exception
                throw;
            }
        }

        public async Task UpdateCategoryAsync(int categoryId, CategoryDto categoryDto)
        {
            try
            {
                // Map the DTO to the entity
                var categoryEntity = _mapper.Map<Category>(categoryDto);

                // Set the CategoryID from the method parameter
                categoryEntity.CategoryID = categoryId;

                // Define your SQL query for updating the category
                var query = @"
            UPDATE Categories
            SET CategoryName = @CategoryName
            WHERE CategoryID = @CategoryID;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the update query
                    await connection.ExecuteAsync(query, categoryEntity);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                // For now, rethrow the exception
                throw;
            }
        }
    }
}
