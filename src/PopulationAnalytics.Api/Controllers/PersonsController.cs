using System.Net;
using Microsoft.AspNetCore.Mvc;
using PopulationAnalyticsApi.Models;
using PopulationAnalyticsApi.Models.Dtos;
using PopulationAnalyticsApi.Services;

namespace PopulationAnalyticsApi.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;
    private readonly IPersonService _personService;

    public PersonsController(ILogger<PersonsController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<PersonDto>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetPersonsAsync([FromQuery] GetPersonsRequest request)
    {
        var persons = await _personService.FindAsync(request.RegionId, request.Identifier);

        return Ok(persons);
    }
    
    [HttpGet("{personId:int}")]
    [ProducesResponseType(typeof(PersonDto), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetPersonByIdAsync([FromRoute] int personId)
    {
        var person = await _personService.FindByIdAsync(personId);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }
    
    [HttpGet("{personId:int}/genetic-proximity")]
    [ProducesResponseType(typeof(GeneticProximityDto), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetGeneticProximityAsync([FromRoute] int personId, [FromBody] PersonGeneticProximityRequest request)
    {
        var result = await _personService.GetGeneticProximityAsync(personId, request.OtherPersonId, request.ProximityThreshold);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
