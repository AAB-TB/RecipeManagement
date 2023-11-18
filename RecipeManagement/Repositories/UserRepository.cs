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

        public UserRepository(DapperConnection dapperConnection, IMapper mapper)
        {
            _dapperConnection = dapperConnection;
            _mapper = mapper;
        }

        public async Task<UserDto> AuthenticateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(int userId, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
