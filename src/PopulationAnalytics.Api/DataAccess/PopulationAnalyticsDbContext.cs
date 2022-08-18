using Microsoft.EntityFrameworkCore;
using PopulationAnalyticsApi.DataAccess.Entities;

namespace PopulationAnalyticsApi.DataAccess;

public class PopulationAnalyticsDbContext: DbContext
{
    public PopulationAnalyticsDbContext(DbContextOptions<PopulationAnalyticsDbContext> options): base(options)
    {
    }

    public DbSet<Region> Regions { get; set; }
    
    public DbSet<Person> Persons { get; set; }
    
    public DbSet<Gene> Genes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Region>(entity =>
        {
            entity.ToTable("Regions");
            entity.HasKey(r => r.Id);
        });
        
        builder.Entity<Person>(entity =>
        {
            entity.ToTable("Persons");
            entity.HasKey(p => p.Id);
            entity.HasOne(p => p.Region)
                .WithMany();
        });
        
        builder.Entity<Gene>(entity =>
        {
            entity.ToTable("Genes");
            entity.HasKey(p => p.Id);
            entity.HasOne(g => g.Person)
                .WithMany(p => p.Genes);
        });
    }
}