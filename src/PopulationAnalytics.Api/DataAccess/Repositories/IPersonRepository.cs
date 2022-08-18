using PopulationAnalyticsApi.DataAccess.Entities;

namespace PopulationAnalyticsApi.DataAccess.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> FindAsync(int? regionId, string? identifier);
    Task<Person?> FindByIdAsync(int personId);
    Task<int> FindGeneticProximityAsync(int personId, int otherPersonId, int proximityThreshold);
}