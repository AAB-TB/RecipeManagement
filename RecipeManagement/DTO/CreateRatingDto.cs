namespace RecipeManagement.DTO
{
    public class CreateRatingDto
    {
        public int RatingID { get; set; }
        public int RatingValue { get; set; }
        public UserProfileDto RaterInfo { get; set; }
    }
}
