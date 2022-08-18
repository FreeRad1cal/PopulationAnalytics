using Microsoft.EntityFrameworkCore;
using PopulationAnalyticsApi.Configuration;
using PopulationAnalyticsApi.DataAccess;
using PopulationAnalyticsApi.DataAccess.Repositories;
using PopulationAnalyticsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnectionFactory, PostgresConnectionFactory>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<IRegionRepository, RegionRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddDbContext<PopulationAnalyticsDbContext>(c =>
    c.UseNpgsql(builder.Configuration.GetConnectionString("PopulationAnalyticsDb"), options =>
    {
        options.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
            errorCodesToAdd: Array.Empty<string>());
    }));
builder.Services.AddSingleton(builder.Configuration.GetRequiredSection("ConfigurationConstants").Get<ConfigurationConstants>());
builder.Services.AddTransient<IDataImporter, DataImporter>();
builder.Services.AddTransient<IRowParser, RowParser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
