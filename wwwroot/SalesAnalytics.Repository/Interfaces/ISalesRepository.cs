using SalesAnalyticsRepository.Models;

namespace SalesAnalyticsRepository.Interfaces;

public interface ISalesRepository
{
    Task<IEnumerable<Sales>> GetSalesSummaryAsync();
}