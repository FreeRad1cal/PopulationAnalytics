using System.ComponentModel.DataAnnotations;

namespace PopulationAnalyticsApi.Models;

public class ImportPopulationRequest
{
    [Required]
    public IFormFile RegionData { get; set; }
    
    [Required]
    public string RegionName { get; set; }
}