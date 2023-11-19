using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("rateRecipe/{userId}/{recipeId}")]
        public async Task<IActionResult> RateRecipeAsync(int userId, int recipeId, [FromBody] CreateRatingDto createRatingDto)
        {
            try
            {
                var result = await _ratingService.RateRecipeAsync(userId, recipeId, createRatingDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{userId}/{recipeId}")]
        public async Task<IActionResult> UpdateRating(int userId, int recipeId, [FromBody] RatingDto ratingDto)
        {
            try
            {
                await _ratingService.UpdateRatingAsync(userId, recipeId, ratingDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating rating");
            }
        }

        [HttpDelete("{userId}/{ratingId}")]
        public async Task<IActionResult> DeleteRating(int userId, int ratingId)
        {
            try
            {
                await _ratingService.DeleteRatingAsync(userId, ratingId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting rating");
            }
        }
    }
}
