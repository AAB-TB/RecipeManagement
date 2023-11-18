using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagement.DTO;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                var createdCategory = await _categoryService.CreateCategoryAsync(categoryDto);
                return createdCategory;
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating category");
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(id, categoryDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating category");
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting category");
            }
        }
    }


}
