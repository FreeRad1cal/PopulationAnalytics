namespace PopulationAnalyticsApi.Models;

public class GetPersonsRequest
{
    public string? Identifier { get; set; }
    
    public int? RegionId { get; set; }
}