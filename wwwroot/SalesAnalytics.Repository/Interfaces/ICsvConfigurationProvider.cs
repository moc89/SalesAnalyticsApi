using CsvHelper.Configuration;

namespace SalesAnalyticsRepository.Interfaces;

public interface ICsvConfigurationProvider
{
    CsvConfiguration GetConfiguration();
}