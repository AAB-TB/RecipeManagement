namespace RecipeManagement.Model
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int RatingValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Recipe Recipe { get; set; }
        public User User { get; set; }
    }
}
