using PopulationAnalyticsApi.DataAccess.Entities;
using PopulationAnalyticsApi.Models;

namespace PopulationAnalyticsApi.Services;

public class RowParser: IRowParser
{
    public Row ParseRow(string row)
    {
        var columns = row.Split(',');
        if (columns.Length < 2)
        {
            throw new ArgumentException("Invalid row format");
        }

        var personIdentifier = columns[0];
        var geneValues = columns[1..].Select(int.Parse);

        return new Row
        {
            Person = new Person()
            {
                Identifier = personIdentifier
            },
            Genes = geneValues.Select(v => new Gene { Value = v })
        };
    }
}