namespace PopulationAnalyticsApi.DataAccess.Entities;

public class Gene
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Value { get; set; }
    
    public int PersonId { get; set; }
    
    public Person Person { get; set; }
}