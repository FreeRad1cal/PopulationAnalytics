using PopulationAnalyticsApi.Models.Dtos;

namespace PopulationAnalyticsApi.Services;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> FindAsync(int? regionId, string? identifier);
    Task<PersonDto> FindByIdAsync(int personId);
    Task<GeneticProximityDto> GetGeneticProximityAsync(int personId, int otherPersonId, int proximityThreshold);
}