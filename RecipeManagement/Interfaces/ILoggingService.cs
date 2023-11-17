namespace RecipeManagement.Interfaces
{
    public interface ILoggingService
    {
        public Task LogMessageAsync(int userId, string logMessage, string logLevel);
    }
}
