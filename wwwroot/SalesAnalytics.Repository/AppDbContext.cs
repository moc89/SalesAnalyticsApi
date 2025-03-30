using Microsoft.EntityFrameworkCore;
using SalesAnalyticsRepository.Models;

namespace SalesAnalyticsRepository;

public class SalesContextAppDbContext(DbContextOptions<SalesContextAppDbContext> options) : DbContext(options)
{
    public DbSet<Sales> Sales { get; set; }
    
}