using AutoMapper;
using Dapper;
using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;
using RecipeManagement.Model;

namespace RecipeManagement.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly DapperConnection _dapperConnection;
        private readonly IMapper _mapper;

        public  UserRepository(DapperConnection dapperConnection, IMapper mapper)
        {
            _dapperConnection = dapperConnection;
            _mapper = mapper;
        }

        public async Task<LoginUserDto> AuthenticateUserAsync(LoginUserDto loginUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserDto> CreateUserAsync(CreateUserDto createUserDto)
        {

            try
            {
                // Map the DTO to the entity
                var userEntity = _mapper.Map<User>(createUserDto);

                // Define your SQL query
                var query = @"
                    INSERT INTO Users (Username, Password, Email, UserRole)
                    VALUES (@Username, @Password, @Email, @UserRole);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and retrieve the generated ID
                    var userId = await connection.QuerySingleAsync<int>(query, userEntity);

                    // Set the generated ID in the DTO
                    //createUserDto.UserID = userId;

                    return createUserDto;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                // Define your SQL query
                var query = "DELETE FROM Users WHERE UserID = @UserId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query
                    await connection.ExecuteAsync(query, new { UserId = userId });
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                // For now, rethrow the exception
                throw;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            try
            {
                // Define your SQL query
                var query = "SELECT * FROM Users;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the results
                    var users = await connection.QueryAsync<UserDto>(query);
                    return users;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            try
            {
                // Define your SQL query
                var query = "SELECT * FROM Users WHERE Email = @Email;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the result
                    var user = await connection.QuerySingleOrDefaultAsync<UserDto>(query, new { Email = email });
                    return user;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                // Define your SQL query
                var query = "SELECT * FROM Users WHERE UserID = @UserId;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the result
                    var user = await connection.QuerySingleOrDefaultAsync<UserDto>(query, new { UserId = userId });
                    return user;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            try
            {
                // Define your SQL query
                var query = "SELECT * FROM Users WHERE Username = @Username;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return the result
                    var user = await connection.QuerySingleOrDefaultAsync<UserDto>(query, new { Username = username });
                    return user;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, throw, etc.)
                throw;
            }
        }

        public async Task UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
        {
            try
            {
                // Map the DTO to the entity
                var userEntity = _mapper.Map<User>(updateUserDto);

                // Set the UserID based on the provided parameter
                userEntity.UserID = userId;

                // Define your SQL query
                var query = @"
            UPDATE Users
            SET Username = @Username, Password = @Password, Email = @Email, UserRole = @UserRole
            WHERE UserID = @UserID;";

                using (var connection = _dapperConnection.GetDbConnection())
                {
                    // Execute the query and return whether any rows were affected
                    var affectedRows = await connection.ExecuteAsync(query, userEntity);
                    
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
