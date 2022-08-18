namespace PopulationAnalyticsApi.Models.Dtos;

public class PersonDto
{
    public int Id { get; set; }
    
    public string Identifier { get; set; }
    
    public RegionDto Region { get; set; }
}