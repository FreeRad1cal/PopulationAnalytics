namespace PopulationAnalyticsApi.Services;

public interface IDataImporter
{
    Task ImportData(Stream data, string regionName);
}