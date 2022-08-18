using PopulationAnalyticsApi.DataAccess.Entities;

namespace PopulationAnalyticsApi.Models;

public class Row
{
    public Person Person { get; set; }
    
    public IEnumerable<Gene> Genes { get; set; }
}