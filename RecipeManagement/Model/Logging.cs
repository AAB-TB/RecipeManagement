namespace RecipeManagement.Model
{
    public class Logging
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string LogMessage { get; set; }
        public string LogLevel { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
