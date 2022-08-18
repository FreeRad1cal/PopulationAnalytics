namespace PopulationAnalyticsApi.Models;

public class PersonGeneticProximityRequest
{
    public int OtherPersonId { get; set; }
    
    public int ProximityThreshold { get; set; }
}