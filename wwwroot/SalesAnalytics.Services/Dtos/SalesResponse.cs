namespace SalesAnalytics.Services.Dtos;

public class SalesResponse: ErrorMessage
{
    public IEnumerable<SalesDto> SalesSummary { get; set; }
}