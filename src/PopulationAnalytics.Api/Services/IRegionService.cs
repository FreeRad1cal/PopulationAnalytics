using PopulationAnalyticsApi.Models.Dtos;

namespace PopulationAnalyticsApi.Services;

public interface IRegionService
{
    Task<IEnumerable<RegionDto>> FindAsync(string? name);
    Task<RegionDto?> FindByIdAsync(int regionId);
    Task<GeneticProximityDto> GetGeneticProximityAsync(int regionId, int otherRegionId, int proximityThreshold);
}