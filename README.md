# ExpertSender

ExpertSender is a web project based on ASP.NET Core that demonstrates CRUD operations for people (People) and their email addresses (Emails). The project uses Entity Framework Core as ORM and libraries such as Bogus for seeding data.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Configuration](#configuration)
- [Database Migrations](#database-migrations)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Technologies](#technologies)

## Requirements

- .NET 8
- SQL Server (or LocalDB)

## Installation

1. **Clone the repository**

    ```sh
    git clone https://github.com/mgrzegorczyk/ExpertSender.git
    cd ExpertSender/src
    ```

2. **Restore dependencies**

    ```sh
    dotnet restore
    ```

## Configuration

1. **Database settings**

    Configure the database connection in the `appsettings.json` file:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ExpertSenderDB;Trusted_Connection=True;MultipleActiveResultSets=true"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*"
    }
    ```

## Database Migrations

1. **Create migrations**

    If you want to create new migrations, use the following command:

    ```sh
    dotnet ef migrations add InitialCreate -p ExpertSender.Infrastructure -s ExpertSender.MVC
    ```

2. **Apply migrations**

    To apply migrations to the database, use the following command:

    ```sh
    dotnet ef database update -p ExpertSender.Infrastructure -s ExpertSender.MVC
    ```

## Running the Application

1. **Run the application**

    ```sh
    dotnet run --project ExpertSender.MVC
    ```

## Project Structure

- `ExpertSender.MVC` - The web application project.
- `ExpertSender.Infrastructure` - The infrastructure project, containing database configuration, migrations, and data seeding.
- `ExpertSender.Domain` - The domain project containing domain logic and entities.
- `ExpertSender.Application` - The application project containing application logic, including repository interfaces and services.

## Technologies

- ASP.NET Core
- Entity Framework Core
- Bogus
- SQL Server
- MediatR
- CQRS

