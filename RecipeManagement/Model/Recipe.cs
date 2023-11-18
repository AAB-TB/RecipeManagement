namespace RecipeManagement.Model
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public string ImagePath { get; set; }

        // Navigation properties for relationships
        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
