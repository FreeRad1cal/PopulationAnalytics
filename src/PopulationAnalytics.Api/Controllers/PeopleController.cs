using Microsoft.AspNetCore.Mvc;
using PopulationAnalyticsApi.Models;

namespace PopulationAnalyticsApi.Controllers;

[ApiController]
[Route("api/people")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> _logger;

    public PeopleController(ILogger<PeopleController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetPeopleAsync()
    {
        return Ok();
    }
    
    [HttpGet("{personId:int}")]
    public async Task<IActionResult> GetPersonByIdAsync([FromRoute] int personId)
    {
        return Ok();
    }
    
    [HttpGet("{personId:int}/genetic-proximity")]
    public async Task<IActionResult> GetPersonGeneticSimilarity([FromRoute] int personId, [FromBody] PersonGeneticProximityRequest request)
    {
        return Ok();
    }
}
