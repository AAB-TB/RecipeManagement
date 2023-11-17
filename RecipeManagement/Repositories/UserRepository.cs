using RecipeManagement.Data;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;
using System;

namespace RecipeManagement.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<UserDto> AuthenticateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(int userId, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
