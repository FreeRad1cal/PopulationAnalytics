using PopulationAnalyticsApi.DataAccess.Repositories;
using PopulationAnalyticsApi.Models.Dtos;

namespace PopulationAnalyticsApi.Services;

public class RegionService: IRegionService
{
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }
    
    public async Task<IEnumerable<RegionDto>> FindAsync(string? name)
    {
        var regions = await _regionRepository.FindAsync(name);

        return regions.Select(r => new RegionDto
        {
            Id = r.Id,
            Name = r.Name
        });
    }

    public async Task<RegionDto?> FindByIdAsync(int regionId)
    {
        var region = await _regionRepository.FindByIdAsync(regionId);

        return region == null
            ? null
            : new RegionDto
            {
                Id = region.Id,
                Name = region.Name
            };
    }

    public async Task<int> GetGeneticProximityAsync(int regionId, int otherRegionId, int proximityThreshold)
    {
        return await _regionRepository.FindGeneticProximityAsync(regionId, otherRegionId, proximityThreshold);
    }
}