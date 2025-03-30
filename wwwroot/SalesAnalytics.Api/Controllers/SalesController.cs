using Microsoft.AspNetCore.Mvc;
using SalesAnalytics.Services.Interfaces;

namespace SalesAnalytics.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController(ILogger<SalesController> logger, ISalesService salesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSalesSummary()
    {
        try
        {
            var result = await salesService.GetSalesSummaryAsync();

            return result.IsSuccess
                ? Ok(result.SalesSummary) 
                : BadRequest(new { result.ErrorMessages, result.ErrorCode });
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unhandled exception in GetSalesSummary");
            return StatusCode(500, new {
                Error = "An unexpected error occurred",
                Reference = Guid.NewGuid().ToString()[..8] // Short ID for support
            });

        }
    }
}