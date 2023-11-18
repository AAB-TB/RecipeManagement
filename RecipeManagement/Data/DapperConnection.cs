using Microsoft.Data.SqlClient;
using System.Data;

namespace RecipeManagement.Data
{
    public class DapperConnection
    {
        private readonly string _connectionString;

        public DapperConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
