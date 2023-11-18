namespace RecipeManagement.DTO
{
    public class RatingDto
    {
        public int RatingValue { get; set; }
        // You might want to add properties for RecipeCreator and RatedRecipe
        public UserDto RecipeCreator { get; set; }
        public RecipeDto RatedRecipe { get; set; }
    }
}
