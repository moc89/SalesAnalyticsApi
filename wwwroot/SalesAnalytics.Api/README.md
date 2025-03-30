# Sales Analytics API

## Overview
The **Sales Analytics API** is a RESTful web service built with .NET9 that allows clients to read data from a csv file. 
## Technologies Used
- **.NET 9** for building the API (.NET Core 3.1 has reached end-of-life (EOL) as of December 13, 2022 and is no longer officially available for download from Microsoft. And .NET Core has been rebranded to just .NET since .NET 5. So, this project needs the latest .NET SDK instead.)
- **C#** for backend development
- **Swagger** for API documentation.
- **Dependency Injection** for managing services
- **Task-based Asynchronous Pattern (TAP)** for asynchronous operations
- **Logging (Console Logging as a placeholder, recommended: Serilog)**

## Endpoints

### 1. Get Sales Data
**GET** `/api/sales`
#### Response:
- **200 OK**: Returns a list of sales data {
  "segment": "Government",
  "country": "Canada",
  "product": "Carretera",
  "discountBand": "None",
  "unitsSold": 1618.5,
  "manufacturingPrice": 3,
  "salePrice": 20,
  "date": "2014-01-01T00:00:00",
  "profit": 27514.5
  }.
- **500 Internal Server Error**: If an error occurs.

## Setup & Installation

### Prerequisites
- .NET 9 (latest version recommended)
- An IDE like Visual Studio, Visual Studio Code, or JetBrains Rider

### Steps to Run
1. Clone the repository
   
2. Go to wwwroot folder and Open SalesAnalytics.sln 

3. Run the application:
   ```sh
   cd SalesAnalytics.Api
   dotnet run
   ```
5. The API will be available at 
   - Api Endpoint: http://localhost:5047/api/sales
   - Swagger: `https://localhost:5047/swagger`

## Improvements & Next Steps
- Implement proper logging with **Serilog** or another logging provider.
- Add more **Unit Tests** for service layers.
- Implement a database (e.g., **SQL Server, PostgreSQL**) for persistent data storage.

## License
This project is open-source and available under the MIT License.
