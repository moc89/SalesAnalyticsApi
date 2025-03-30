namespace SalesAnalytics.Services.Dtos;

public class ErrorMessage
{
    public string? ErrorMessages { get; set; } = "Successfully retrieved response";
    public int ErrorCode { get; set; } = 0;
    public string? ErrorDetail { get; set; } = "";
    public bool IsSuccess { get; set; } = true;
}