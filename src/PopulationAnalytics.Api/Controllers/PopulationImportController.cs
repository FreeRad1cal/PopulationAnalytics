using Microsoft.AspNetCore.Mvc;
using PopulationAnalyticsApi.Models;

namespace PopulationAnalyticsApi.Controllers;

[ApiController]
[Route("api/population-import")]
public class PopulationImportController : ControllerBase
{
    private readonly ILogger<PopulationImportController> _logger;

    public PopulationImportController(ILogger<PopulationImportController> logger)
    {
        _logger = logger;
    }

    [HttpPost("")]
    public async Task<IActionResult> ImportPopulationData([FromForm] ImportPopulationRequest request)
    {
        return Ok();
    }
}
