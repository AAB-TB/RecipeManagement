using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<CreateUserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
        Task DeleteUserAsync(int userId);
        Task<LoginUserDto> AuthenticateUserAsync(LoginUserDto loginUserDto);


    }
}
