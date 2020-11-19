using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public interface IDbConnection
    {
        public SqlConnection GetConnection { get; }
    }
    public class DbConnection : IDbConnection
    {
        IConfiguration Configuration;

        public DbConnection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SqlConnection GetConnection
        {
            get {
                var connectionString = Configuration
                    .GetConnectionString("DbContextConnection");
                return new SqlConnection(connectionString);
            }
        }

    }
}
