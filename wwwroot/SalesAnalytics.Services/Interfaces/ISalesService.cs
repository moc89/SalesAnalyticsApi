using SalesAnalytics.Services.Dtos;

namespace SalesAnalytics.Services.Interfaces;

public interface ISalesService
{
    Task<SalesResponse> GetSalesSummaryAsync();
}