using System.Globalization;
using CsvHelper.Configuration;
using SalesAnalyticsRepository.Interfaces;

namespace SalesAnalyticsRepository.Utils;

public class CsvConfigurationProvider : ICsvConfigurationProvider
{
    public CsvConfiguration GetConfiguration() => new(CultureInfo.InvariantCulture)
    {
        PrepareHeaderForMatch = args => args.Header.Trim(),
        MissingFieldFound = null,
        HeaderValidated = null,
        TrimOptions = TrimOptions.Trim,
    };
}