using PopulationAnalyticsApi.DataAccess.Repositories;
using PopulationAnalyticsApi.Models.Dtos;

namespace PopulationAnalyticsApi.Services;

public class PersonService: IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    public async Task<IEnumerable<PersonDto>> FindAsync(int? regionId, string? identifier)
    {
        var persons = await _personRepository.FindAsync(regionId, identifier);

        return persons.Select(p => new PersonDto
        {
            Id = p.Id,
            Identifier = p.Identifier,
            Region = new RegionDto
            {
                Id = p.RegionId,
                Name = p.Region?.Name
            }
        });
    }

    public async Task<PersonDto> FindByIdAsync(int personId)
    {
        var person = await _personRepository.FindByIdAsync(personId);

        return person == null
            ? null
            : new PersonDto
            {
                Id = person.Id,
                Identifier = person.Identifier,
                Region = new RegionDto
                {
                    Id = person.RegionId,
                    Name = person.Region?.Name
                }
            };
    }

    public async Task<int?> GetGeneticProximityAsync(int personId, int otherPersonId, int proximityThreshold) => 
        await _personRepository.FindGeneticProximityAsync(personId, otherPersonId, proximityThreshold);
}