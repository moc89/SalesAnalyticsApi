using Microsoft.EntityFrameworkCore;
using SalesAnalytics.Services.Interfaces;
using SalesAnalytics.Services.Services;
using SalesAnalyticsRepository;
using SalesAnalyticsRepository.Interfaces;
using SalesAnalyticsRepository.Repositories;
using SalesAnalyticsRepository.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SalesContextAppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddSingleton<ICsvConfigurationProvider, CsvConfigurationProvider>();
builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:5173") 
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();