using Microsoft.AspNetCore.Mvc;
using PopulationAnalyticsApi.Models;

namespace PopulationAnalyticsApi.Controllers;

[ApiController]
[Route("api/regions")]
public class RegionsController : ControllerBase
{
    private readonly ILogger<RegionsController> _logger;

    public RegionsController(ILogger<RegionsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetRegionsAsync()
    {
        return Ok();
    }
    
    [HttpGet("{regionId:int}")]
    public async Task<IActionResult> GetRegionByIdAsync([FromRoute] int regionId)
    {
        return Ok();
    }
    
    [HttpGet("{regionId:int}/genetic-proximity")]
    public async Task<IActionResult> GetRegionGeneticSimilarity([FromRoute] int regionId, [FromBody] RegionGeneticProximityRequest request)
    {
        return Ok();
    }
}
