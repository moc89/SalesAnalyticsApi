using Microsoft.Extensions.Logging;
using SalesAnalytics.Services.Dtos;
using SalesAnalytics.Services.Interfaces;
using SalesAnalyticsRepository.Interfaces;

namespace SalesAnalytics.Services.Services;

public class SalesService(ILogger<SalesService> logger, ISalesRepository salesRepository)
    : ISalesService
{
    public async Task<SalesResponse> GetSalesSummaryAsync()
    {
        try
        {
            logger.LogInformation("Fetching all sales");

            // Get product list
            var sales = await salesRepository.GetSalesSummaryAsync();

            var salesResponse = sales.Select(p => new SalesDto
            {
                Segment = p.Segment,
                Country = p.Country,
                Product = p.Product,
                DiscountBand = p.DiscountBand,
                UnitsSold = p.UnitsSold,
                ManufacturingPrice = p.ManufacturingPrice,  
                SalePrice = p.SalePrice,    
                Date = p.Date,
            });
            
            return new SalesResponse(){ SalesSummary = salesResponse };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while fetching sales.");
            // Note: We can create our own exception class and throw meaningful message here
            return new SalesResponse(){ ErrorMessages = "An error occurred while fetching sales.", IsSuccess = false, ErrorDetail = ex.ToString() , ErrorCode = 101};
        }
    }
}