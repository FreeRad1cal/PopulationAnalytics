using PopulationAnalyticsApi.Models;

namespace PopulationAnalyticsApi.Services;

public interface IRowParser
{
    Row ParseRow(string row);
}