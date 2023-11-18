namespace RecipeManagement.DTO
{
    public class UpdateRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string ImagePath { get; set; }

        // You might want to add properties for Category and User information
        public UpdateCategoryDto Category { get; set; }
        
    }
}
