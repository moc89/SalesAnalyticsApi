using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using SalesAnalyticsRepository.Utils;

namespace SalesAnalyticsRepository.Models;

public class Sales
{
    [StringLength(200)]  
    [Name("Segment")]
    public string? Segment { get; set; }
    
    [StringLength(200)]  
    [Name("Country")]
    public string? Country { get; set; }
    
    [StringLength(200)]  
    [Name("Product")]
    public string? Product { get; set; }
    
    [StringLength(200)]  
    [Name("Discount Band")]
    public string? DiscountBand { get; set; }
    
    [Name("Units Sold")]
    [TypeConverter(typeof(CurrencyDecimalConverter))]
    public decimal UnitsSold { get; init; }
    
    [Name("Manufacturing Price")]
    [TypeConverter(typeof(CurrencyDecimalConverter))]
    public decimal ManufacturingPrice { get; set; }
    [StringLength(10)]  
    public string? ManufacturingCurrency { get; set; }
    
    [Name("Sale Price")]
    [TypeConverter(typeof(CurrencyDecimalConverter))]
    public decimal SalePrice { get; set; }
    
    [Name("Date")]
    public DateTime Date { get; set; }
    
    // Calculated property
    public decimal GrossRevenue => UnitsSold * SalePrice;
    public decimal ManufacturingCost => UnitsSold * ManufacturingPrice;
    public decimal Profit => GrossRevenue - ManufacturingCost;
}