namespace RecipeManagement.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        // You might want to add properties for Recipes
        public ICollection<RecipeDto> Recipes { get; set; }
    }
}
