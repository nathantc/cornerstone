# Data API Project Setup

The following steps are to set up the DataAPI project.

## 1. Install Packages

Install Swagger support packages:
```
dotnet add package Swashbuckle.AspNetCore
```
Install Sqlite support packages:
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
[Needs description]
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
Install Entity Framework Core Tools for creating database migrations.
```
dotnet tool install --global dotnet-ef
```

## 2. Run Data Migrations

# Database Creation

## 1. Add InitialCreate Migration

Run the command: 
```
 dotnet-ef migrations add InitialCreate
```
