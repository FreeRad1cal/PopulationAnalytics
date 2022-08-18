using Dapper;
using Microsoft.EntityFrameworkCore;
using PopulationAnalyticsApi.DataAccess.Entities;

namespace PopulationAnalyticsApi.DataAccess.Repositories;

public class PersonRepository: IPersonRepository
{
    private readonly PopulationAnalyticsDbContext _dbContext;
    private readonly IDbConnectionFactory _connectionFactory;

    public PersonRepository(PopulationAnalyticsDbContext dbContext, IDbConnectionFactory connectionFactory)
    {
        _dbContext = dbContext;
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Person>> FindAsync(int? regionId, string? identifier)
    {
        var query = _dbContext.Persons
            .Include(p => p.Region)
            .AsNoTracking();

        if (regionId != null)
        {
            query = query.Where(p => p.RegionId == regionId);
        }

        if (identifier != null)
        {
            query = query.Where(p => p.Identifier == identifier);
        }

        return await query.ToListAsync();
    }

    public async Task<Person?> FindByIdAsync(int personId) =>
        await _dbContext.Persons
            .Include(p => p.Region)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == personId);

    public async Task<int> FindGeneticProximityAsync(int personId, int otherPersonId, int proximityThreshold)
    {
        using var connection = await _connectionFactory.OpenConnectionAsync();

        const string sql = @$"
                                SELECT COUNT(*)
                                FROM Genes g1
                                JOIN Genes g2
                                ON g1.Name = g2.Name
                                WHERE g1.Id < g2.Id 
                                        && g1.PersonId = @{nameof(personId)} 
                                        && g2.PersonId = @{nameof(otherPersonId)} 
                                        && ABS(g1.Value - g2.Value) < @{nameof(proximityThreshold)};
                            ";

        var response = await connection.QueryAsync<int>(sql, new { personId, otherPersonId, proximityThreshold });
        var proximity = response.First();

        return proximity;
    }
}