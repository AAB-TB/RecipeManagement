using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("recipesByUser/{username}")]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByUsername(string username)
        {
            try
            {
                var recipes = await _recipeService.GetRecipesByUsernameAsync(username);
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving recipes");
            }
        }

        [HttpPost("{userId}/{categoryId}")]
        public async Task<ActionResult<CreateRecipeDto>> CreateRecipe(int userId, int categoryId, [FromBody] CreateRecipeDto createRecipeDto)
        {
            try
            {
                var createdRecipe = await _recipeService.CreateRecipeAsync(userId, categoryId, createRecipeDto);

                return createdRecipe;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating recipe");
            }
        }

        // DELETE: api/Recipe/userId/recipeId
        [HttpDelete("{userId}/{recipeId}")]
        public async Task<IActionResult> DeleteRecipe(int userId, int recipeId)
        {
            try
            {
                await _recipeService.DeleteRecipeAsync(userId, recipeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting recipe");
            }
        }

        // GET: api/Recipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAllRecipes()
        {
            try
            {
                var recipes = await _recipeService.GetAllRecipesAsync();
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving recipes");
            }
        }

        // GET: api/Recipe/recipeId
        [HttpGet("{recipeId}")]
        public async Task<ActionResult<RecipeDto>> GetRecipeById(int recipeId)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);
                if (recipe == null)
                {
                    return NotFound();
                }
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving recipe");
            }
        }

        // GET: api/Recipe/title/recipeTitle
        [HttpGet("title/{recipeTitle}")]
        public async Task<ActionResult<RecipeDto>> GetRecipeByTitle(string recipeTitle)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeByTitleAsync(recipeTitle);
                if (recipe == null)
                {
                    return NotFound();
                }
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving recipe by title");
            }
        }

        // GET: api/Recipe/category/categoryName
        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByCategoryName(string categoryName)
        {
            try
            {
                var recipes = await _recipeService.GetRecipesByCategoryName(categoryName);
                if (recipes == null)
                {
                    return NotFound();
                }
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving recipes by category name");
            }
        }

        // PUT: api/Recipe/userId/recipeId
        [HttpPut("{userId}/{recipeId}")]
        public async Task<IActionResult> UpdateRecipe(int userId, int recipeId, [FromBody] UpdateRecipeDto updateRecipeDto)
        {
            try
            {
                await _recipeService.UpdateRecipeAsync(userId, recipeId, updateRecipeDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating recipe");
            }
        }
    }
}