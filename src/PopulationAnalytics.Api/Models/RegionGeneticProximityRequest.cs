namespace PopulationAnalyticsApi.Models;

public class RegionGeneticProximityRequest
{
    public int OtherRegionId { get; set; }
    
    public int ProximityThreshold { get; set; }
}