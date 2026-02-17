# HVAC Management System (Enterprise Baseline)

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4)
![License](https://img.shields.io/badge/license-MIT-green)

## Overview
HVACManagement is a .NET 8 ASP.NET Core MVC enterprise baseline for HVAC/MEP project and workforce operations. It includes Identity-based authentication, EF Core code-first data layer, repository/unit-of-work abstraction, service layer orchestration, SignalR notifications, structured logging via Serilog, and seeded startup data for rapid environment bootstrapping.

## Implemented Baseline Modules
- Authentication (Login/Logout with lockout support).
- Dashboard summary.
- Project listing and creation.
- Attendance check-in / check-out service flow.
- API endpoints for project progress and notification retrieval.
- SignalR notification hub.

## Technology Stack
- .NET 8 / ASP.NET Core MVC
- C# 12
- EF Core 8 + SQL Server
- ASP.NET Core Identity
- Serilog
- Hangfire packages referenced for job scheduling integration
- MailKit package referenced for email integration
- EPPlus package referenced for Excel export integration

## Setup
1. Install .NET 8 SDK.
2. Install SQL Server Express and SSMS.
3. Update `appsettings.json` connection string.
4. Run:
   - `dotnet restore`
   - `dotnet ef database update`
   - `dotnet run`
5. Login with seeded account: `superadmin@hvac.com / SuperAdmin@123!`.

## Project Structure
- `Controllers`: MVC and API controllers.
- `Models/Domain`: Core entities.
- `Models/Enums`: Enum catalogs.
- `Data`: EF Core DbContext and seed initializer.
- `Repositories`: Generic repository and unit-of-work.
- `Services`: Domain services.
- `Views`: Razor views and shared layout.
- `Middleware`: Global exception handling.
- `Hubs`: SignalR hubs.

## Notes
This repository now contains a production-grade architectural baseline intended to be extended module-by-module for full enterprise scope.

## License
MIT.
