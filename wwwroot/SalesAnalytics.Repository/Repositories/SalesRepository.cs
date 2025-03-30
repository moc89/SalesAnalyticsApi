using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using SalesAnalyticsRepository.Interfaces;
using SalesAnalyticsRepository.Models;
using Microsoft.Extensions.Hosting;

namespace SalesAnalyticsRepository.Repositories;

public class SalesRepository(SalesContextAppDbContext context, IHostEnvironment env, ICsvConfigurationProvider configProvider)
    : SalesContextAppDbContext(options: new DbContextOptions<SalesContextAppDbContext>()), ISalesRepository
{
    
    public async Task<IEnumerable<Sales>> GetSalesSummaryAsync()
    {
        try
        {
            var solutionRoot = Path.Combine(env.ContentRootPath, "..", ".."); // Go up 2 levels
            var filePath = Path.GetFullPath(Path.Combine(solutionRoot, "App_Data", "data.csv"));
            
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Sales data file not found at: {filePath}");
            }

            if (new FileInfo(filePath).Length == 0)
            {
                throw new InvalidDataException("Sales data file is empty");
            }
            
            var records = new List<Sales>();

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, configProvider.GetConfiguration());
            
            await foreach (var record in csv.GetRecordsAsync<Sales>())
            {
                records.Add(record);
            }

            return records;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // Return default error product
            return new List<Sales>
            {
                new Sales { Segment = "Error" }
            };
        }
    }
}