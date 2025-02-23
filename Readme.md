# Plant Performance Analyzer
# Overview
This project is a Plant Performance Analyzer built using ASP.NET Core 9 and follows the Clean Architecture principles. It calculates the performance zone (Robust, Stable, Reactive, or Overloaded) based on the average alarm rate and the percentage of time spent outside the target. Additionally, it includes CRUD operations for managing alarms, with data stored in a PostgreSQL database.

# Features
1. Performance Zone Calculation:

  Determines the performance zone (Robust, Stable, Reactive, or Overloaded) based on:
    Average Alarm Rate (X-axis).
    Percentage of Time Spent Outside Target (Y-axis).

2. CRUD Operations for Alarms:

  Create, Read, Update, and Delete alarm records.
  Stores alarm data in a PostgreSQL database.

3. Clean Architecture:

  Separates concerns into layers:
    A. MacSolution.Domain: Core business logic and entities.
    B. MacSolution.Application: Use cases and business rules.
    C. MacSolution.Infrastructure: Database and external services.
    D. MacSolution.API (Presentation): API controllers and HTTP handling.

4. PostgreSQL Database:

  Uses PostgreSQL for data persistence.
  Entity Framework Core for database operations.

# Prerequisites
Before running the project, ensure you have the following installed:

  .NET 9 SDK
  PostgreSQL (Optional)
  Entity Framework Core Tools (for database migrations)

# Getting Started
1. Clone the Repository
2. Set Up the Database
  
  I. Install PostgreSQL:
        Download and install PostgreSQL from the official website.
        Create a new database (e.g., PlantPerformanceDB).

  II. Update Connection String:
        Open appsettings.json in the MacSolution.API project.
        Update the ConnectionStrings section with your PostgreSQL credentials:

      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=PlantPerformanceDB;Username=your-username;Password=your-password"
      }

  III. Run Database Migrations:
        Navigate to the MacSolutions.Infrastructure project folder.
        Run the following commands to apply migrations:
        dotnet ef database update

3. Run the Application 
  I. Run the API
    Navigate to the MacSolutions.API project folder.
    Start the application: dotnet run

  II. Access the API
    The API will be available at http://localhost:5000/swagger/index.html

# API Endpoints
##  Performance Zone Calculation
    Endpoint: POST /api/plantperformance/determinezone
    Request Query string: averageAlarmRate, percentageOutsideTarget
    Response Json: 
      {
        "zone": "Reactive"
      }
# Project Structure
MacSolutionsAPI/
├── MacSolutions.Domain/                  # Core business logic and entities
│   ├── Entities/
│   └── Enums/
├── MacSolutions.Application/             # Use cases and business rules
│   ├── Services/
│   └── DTOs/
├── MacSolutions.Infrastructure/          # Database and external services
│   ├── Data/
│   └── Migrations/
├── MacSolutions.API/                     # API controllers and HTTP handling
│   ├── Controllers/
│   └── appsettings.json

# Technologies Used
  Backend: ASP.NET Core 9
  Database: PostgreSQL
  ORM: Entity Framework Core
  Architecture: Clean Architecture

# License
  This project is licensed under the MIT License. 