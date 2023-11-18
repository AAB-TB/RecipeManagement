namespace RecipeManagement.DTO
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }

        // You might want to add properties for Recipes and Ratings
        public ICollection<RecipeDto> Recipes { get; set; }
        public ICollection<RatingDto> Ratings { get; set; }
    }
}
