namespace RecipeManagement.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
