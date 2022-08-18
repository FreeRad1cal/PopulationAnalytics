using System.Data;

namespace PopulationAnalyticsApi.DataAccess;

public interface IDbConnectionFactory
{
    Task<IDbConnection> OpenConnectionAsync();
}