using RecipeManagement.DTO;
using RecipeManagement.Model;

namespace RecipeManagement.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(int userId, UserDto userDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<UserDto> AuthenticateUserAsync(User user);


    }
}
