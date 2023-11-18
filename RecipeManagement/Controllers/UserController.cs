using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving users");
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                {
                    // Return a 404 Not Found if the user with the specified ID is not found
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving user");
            }
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);
                if (user == null)
                {
                    return NotFound($"User with username {username} not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving user");
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);
                if (user == null)
                {
                    return NotFound($"User with email {email} not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving user");
            }
        }

       
        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var createdUser = await _userService.CreateUserAsync(createUserDto);

                return createdUser;
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating user");
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
            await _userService.UpdateUserAsync(id, updateUserDto);

                

                // Return the updated user
                var updatedUser = await _userService.GetUserByIdAsync(id);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user");
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                
                await _userService.DeleteUserAsync(id);


                

                // Return a 204 No Content on successful deletion
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting user");
            }
        }

    }
}
