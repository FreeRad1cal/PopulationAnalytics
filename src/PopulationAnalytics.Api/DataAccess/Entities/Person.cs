namespace PopulationAnalyticsApi.DataAccess.Entities;

public class Person
{
    public int Id { get; set; }
    
    public string Identifier { get; set; }
    
    public int RegionId { get; set; }
    
    public Region Region { get; set; }
    
    public IEnumerable<Gene> Genes { get; set; }
}
