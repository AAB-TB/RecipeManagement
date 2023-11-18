namespace RecipeManagement.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<Recipe> Recipes { get; set; }
    }
}
