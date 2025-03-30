using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace SalesAnalyticsRepository.Utils;

public class CurrencyDecimalConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0m; // Default value for empty fields

        // 1. Fix encoding artifacts (�) and extract currency symbol
        text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        
        // 2. Remove all non-numeric characters except decimal point and minus
        var nonNumericChars = Regex.Replace(text, @"[^\d.-]", "");
        
        // 3. Remove all whitespace between digits
        var cleanValue = Regex.Replace(nonNumericChars, @"(\d)\s+(\d)", "$1$2");
        
        
        // Remove all currency symbols and thousands separators
        cleanValue = cleanValue
            .Replace("£", "")
            .Replace("$", "")
            .Replace("€", "")
            .Replace(",", "")
            .Trim();

        // Use .NET 9's decimal parsing with invariant culture
        if (decimal.TryParse(cleanValue, 
                NumberStyles.Number | NumberStyles.AllowCurrencySymbol, 
                CultureInfo.InvariantCulture, 
                out var result))
        {
            return result;
        }

        throw new TypeConverterException(this, memberMapData, text, row.Context, 
            $"Failed to parse '{text}' as decimal.");
    }

    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        return ((decimal)value).ToString(CultureInfo.InvariantCulture);
    }
}