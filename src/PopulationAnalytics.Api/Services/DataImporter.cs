using PopulationAnalyticsApi.Configuration;
using PopulationAnalyticsApi.DataAccess.Entities;
using PopulationAnalyticsApi.DataAccess.Repositories;
using PopulationAnalyticsApi.Models;

namespace PopulationAnalyticsApi.Services;

public class DataImporter: IDataImporter
{
    private readonly ConfigurationConstants _constants;
    private readonly IRowParser _rowParser;
    private readonly IRegionRepository _regionRepository;

    public DataImporter(ConfigurationConstants constants, IRowParser rowParser, IRegionRepository regionRepository)
    {
        _constants = constants;
        _rowParser = rowParser;
        _regionRepository = regionRepository;
    }
    
    public async Task ImportData(Stream data, string regionName)
    {
        var reader = new StreamReader(data);
        var header = await reader.ReadLineAsync();
        if (header == null)
        {
            throw new BadHttpRequestException("Invalid file format");
        }
        var geneNames = header.Split(',')[1..];
        var batchSize = _constants.ImportBatchSize;

        var region = new Region { Name = regionName };
        await _regionRepository.AddRegionAsync(region);
        
        while (!reader.EndOfStream)
        {
            var rows = (await GetBatchOfRowsAsync(reader, batchSize)).ToList();

            throw new NotImplementedException();
        }
    }
    
    private async Task<IEnumerable<Row>> GetBatchOfRowsAsync(StreamReader reader, int batchSize)
    {
        var rows = new List<Row>();
        for (var i = 0; i < batchSize && !reader.EndOfStream; i++)
        {
            var line = await reader.ReadLineAsync() ?? string.Empty;
            rows.Add(_rowParser.ParseRow(line));
        }

        return rows;
    }
}