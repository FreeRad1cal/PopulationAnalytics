using Dapper;
using Microsoft.EntityFrameworkCore;
using PopulationAnalyticsApi.DataAccess.Entities;

namespace PopulationAnalyticsApi.DataAccess.Repositories;

public class RegionRepository: IRegionRepository
{
    private readonly PopulationAnalyticsDbContext _dbContext;
    private readonly IDbConnectionFactory _connectionFactory;

    public RegionRepository(PopulationAnalyticsDbContext dbContext, IDbConnectionFactory connectionFactory)
    {
        _dbContext = dbContext;
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Region>> FindAsync(string? name)
    {
        var query = _dbContext.Regions.AsNoTracking();

        if (name != null)
        {
            query = query.Where(r => r.Name == name);
        }

        return await query.ToListAsync();
    }

    public async Task<Region?> FindByIdAsync(int regionId) =>
        await _dbContext.Regions
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == regionId);

    public async Task<int> FindGeneticProximityAsync(int regionId, int otherRegionId, int proximityThreshold)
    {
        var regionAvgGeneValues = await FindAverageGeneValues(regionId);
        var otherRegionAvgGeneValues = await FindAverageGeneValues(otherRegionId);

        var proximity = regionAvgGeneValues
            .Join(otherRegionAvgGeneValues, g => g.GeneName, g => g.GeneName,
                (g1, g2) => Math.Abs(g1.MeanValue - g2.MeanValue))
            .Count(diff => diff < proximityThreshold);

        return proximity;
    }

    private async Task<IEnumerable<(string GeneName, int MeanValue)>> FindAverageGeneValues(int regionId)
    {
        using var connection = await _connectionFactory.OpenConnectionAsync();
        
        const string sql = @$"
                                SELECT Name, AVG(CAST(Value as BIGINT)) as Value
                                FROM Genes g
                                JOIN Persons p
                                    ON g.PersonId = p.Id
                                JOIN Regions r
                                    ON p.RegionId = r.Id
                                WHERE r.Id = @{nameof(regionId)}
                                GROUP BY Name;
                            ";
        
        var response = await connection.QueryAsync<Gene>(sql, new { regionId });

        return response.Select(g => (g.Name, g.Value));
    }
}