using RecipeManagement.Data;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Repositories
{
    public class LoggingRepository : ILoggingService
    {
        private readonly DapperContext _context;
        public LoggingRepository(DapperContext context)
        {
            _context = context;
        }
        public Task LogMessageAsync(int userId, string logMessage, string logLevel)
        {
            throw new NotImplementedException();
        }
    }
}
