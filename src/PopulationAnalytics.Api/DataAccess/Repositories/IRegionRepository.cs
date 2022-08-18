using PopulationAnalyticsApi.DataAccess.Entities;

namespace PopulationAnalyticsApi.DataAccess.Repositories;

public interface IRegionRepository
{
    Task AddRegionAsync(Region region);
    Task<IEnumerable<Region>> FindAsync(string? name);
    Task<Region?> FindByIdAsync(int regionId);
    Task<int> FindGeneticProximityAsync(int regionId, int otherRegionId, int proximityThreshold);
}