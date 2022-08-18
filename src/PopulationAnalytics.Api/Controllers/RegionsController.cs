using System.Net;
using Microsoft.AspNetCore.Mvc;
using PopulationAnalyticsApi.Models;
using PopulationAnalyticsApi.Models.Dtos;
using PopulationAnalyticsApi.Services;

namespace PopulationAnalyticsApi.Controllers;

[ApiController]
[Route("api/regions")]
public class RegionsController : ControllerBase
{
    private readonly ILogger<RegionsController> _logger;
    private readonly IRegionService _regionService;

    public RegionsController(ILogger<RegionsController> logger, IRegionService regionService)
    {
        _logger = logger;
        _regionService = regionService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetRegionsAsync([FromQuery] GetRegionsRequest request)
    {
        var regions = await _regionService.FindAsync(request.Name);

        return Ok(regions);
    }
    
    [HttpGet("{regionId:int}")]
    public async Task<IActionResult> GetRegionByIdAsync([FromRoute] int regionId)
    {
        var person = await _regionService.FindByIdAsync(regionId);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }
    
    [HttpGet("{regionId:int}/genetic-proximity")]
    [ProducesResponseType(typeof(GeneticProximityDto), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetGeneticProximityAsync([FromRoute] int regionId, [FromBody] RegionGeneticProximityRequest request)
    {
        var result = await _regionService.GetGeneticProximityAsync(regionId, request.OtherRegionId, request.ProximityThreshold);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
