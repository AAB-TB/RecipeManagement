using RecipeManagement.DTO;

namespace RecipeManagement.Interfaces
{
    public interface IUserService
    {
        public Task<int> CreateUserAsync(UserDto userDto);
        public Task<UserDto> AuthenticateUserAsync(string username, string password);
        public Task<bool> UpdateUserAsync(int userId, UserDto userDto);
        public Task<bool> DeleteUserAsync(int userId);

    }
}
