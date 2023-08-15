# CarInfoSys Project

This project is built with .NET Core and uses Entity Framework Core for data access. The data is managed using the PostgreSQL database and is hosted locally. Please follow the instructions below to set up and run the project.

## Prerequisites

Before you begin, ensure you have the following installed:

1. .NET Core SDK 3.0.0
2. PostgreSQL database (with Npgsql driver) 3.0.0
3. Microsoft.VisualStudio.Web.CodeGeneration package 3.0.0

## Setting Up the Database

1. Create a PostgreSQL database named `CarInfoDB` on your local PostgreSQL instance.
2. Update the connection string in `appsettings.json` to match your local PostgreSQL configuration.

## Migrating and Updating Data

1. Open a terminal in the project directory.
2. Run the following commands to migrate the database and apply any pending updates:


   dotnet ef database update
