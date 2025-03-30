using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SalesAnalytics.Controllers;
using SalesAnalytics.Services.Dtos;
using SalesAnalytics.Services.Interfaces;

namespace SalesAnalytics.UnitTest;


// Write test a few cases and README.md file for the BACKEND... 
public class SalesAnalyticsTests
{
    private readonly Mock<ISalesService> _mockSalesService;
    private readonly Mock<ILogger<SalesController>> _mockLogger;
    private readonly SalesController _controller;

    public SalesAnalyticsTests()
    {
        _mockSalesService = new Mock<ISalesService>();
        _mockLogger = new Mock<ILogger<SalesController>>();
        _controller = new SalesController(_mockLogger.Object, _mockSalesService.Object);
    }

    [Fact]
    public async Task GetSalesSummary_ReturnsOk_WhenServiceReturnsSuccess()
    {
        // Arrange
        var salesResponse = new SalesResponse { IsSuccess = true, SalesSummary = new List<SalesDto>() };
        _mockSalesService.Setup(s => s.GetSalesSummaryAsync()).ReturnsAsync(salesResponse);

        // Act
        var result = await _controller.GetSalesSummary();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
    
    [Fact]
    public async Task GetSalesSummary_ReturnsBadRequest_WhenServiceFails()
    {
        // Arrange
        var salesResponse = new SalesResponse { IsSuccess = false, ErrorMessages = "Error occurred", ErrorCode = 101 };
        _mockSalesService.Setup(s => s.GetSalesSummaryAsync()).ReturnsAsync(salesResponse);

        // Act
        var result = await _controller.GetSalesSummary();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.NotNull(badRequestResult.Value);
    }
}