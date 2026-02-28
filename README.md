# FSTAssessment
Task

# Tech Stack

## Backend
- .NET 10
- ASP.NET Core Web API
- EF Core (InMemory)
- xUnit
- Moq
- WebApplicationFactory (Integration Testing)
- Swagger / OpenAPI

## Frontend
- React
- TypeScript
- Vite
- Fetch API


## Backend Setup

- .NET SDK (8.0 or 10.0)
- Node.js (18+ recommended)
- git clone repo
- Running the Backend

From solution root: run below cmd one by one

dotnet restore
dotnet build
dotnet run --project src/OrderTracker.Api

## output will be
- https://localhost:{port}/swagger

## for Test Run
- dotnet test

# Frontend side

- cd frontend/order-tracker-ui
- npm install
- npm run dev

# Notes
- change base url in api/orderApi.ts