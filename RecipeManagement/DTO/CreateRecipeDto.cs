namespace RecipeManagement.DTO
{
    public class CreateRecipeDto
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string ImagePath { get; set; }

        // You might want to add properties for Category and User information
        //public CreateCategoryDto Category { get; set; }
        //public UserProfileDto User { get; set; }
    }
}
