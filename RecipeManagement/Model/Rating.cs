namespace RecipeManagement.Model
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int RecipeCreatorID { get; set; }
        public int RatingValue { get; set; }
        public int RatedRecipeID { get; set; }
        public int RatingUserID { get; set; }

        // Navigation properties for relationships
        public User RecipeCreator { get; set; }
        public Recipe RatedRecipe { get; set; }
        public User RatingUser { get; set; }
    }
}
