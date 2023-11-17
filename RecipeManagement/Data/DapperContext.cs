using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RecipeManagement.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            // Retrieve the connection string from the appsettings.json file
            _connectionString = configuration.GetConnectionString("MyDatabaseConnection");
        }

        private IDbConnection CreateConnection()
        {
            // Use Dapper's IDbConnection interface to create a connection
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                // Use Dapper to execute the query and map the results to the specified type
                return connection.Query<T>(sql, parameters);
            }
        }

        public int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                // Use Dapper to execute a non-query (e.g., insert, update, delete)
                return connection.Execute(sql, parameters);
            }
        }

    }
}
