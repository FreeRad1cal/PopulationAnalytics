using System.Data;
using Npgsql;
using PopulationAnalyticsApi.DataAccess;

namespace PopulationAnalyticsApi.Services;

public class PostgresConnectionFactory: IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public PostgresConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<IDbConnection> OpenConnectionAsync()
    {
        var connectionString = _configuration.GetConnectionString("PopulationAnalyticsDb");
        var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        return connection;
    }
}