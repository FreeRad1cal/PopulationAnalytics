using Microsoft.AspNetCore.Mvc;
using PopulationAnalyticsApi.Models;
using PopulationAnalyticsApi.Services;

namespace PopulationAnalyticsApi.Controllers;

[ApiController]
[Route("api/population-import")]
public class PopulationImportController : ControllerBase
{
    private readonly ILogger<PopulationImportController> _logger;
    private readonly IDataImporter _dataImporter;

    public PopulationImportController(ILogger<PopulationImportController> logger, IDataImporter dataImporter)
    {
        _logger = logger;
        _dataImporter = dataImporter;
    }

    [HttpPost("")]
    public async Task<IActionResult> ImportPopulationData([FromForm] ImportPopulationRequest request)
    {
        if (request.RegionData.Length == 0)
        {
            _logger.LogError("Empty file submitted");
            return BadRequest("A nonempty file is required");
        }
        
        await using var stream = request.RegionData.OpenReadStream();
        await _dataImporter.ImportData(stream, request.RegionName);
        
        return Ok();
    }
}
