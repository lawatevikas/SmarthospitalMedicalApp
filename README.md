# Clinora

Clinora is a modern healthcare management platform for clinics and healthcare staff. The V1 web application is designed for Doctor/Admin and Pharmacist roles, with a backend authorization model that can support additional roles later.

## Architecture

Clinora is a modular monolith with Clean Architecture boundaries:

- Angular web client communicates with the ASP.NET Core REST API.
- The API delegates business workflows to the Application layer.
- Application depends on Domain abstractions and rules.
- Infrastructure implements persistence and external-service concerns and is wired at the API composition root.
- MongoDB Atlas is the only application database.

The backend derives clinic context from the authenticated identity and scopes tenant-owned data accordingly. Pharmacist workflows are designed around minimum-necessary data and dedicated API contracts. See [`docs/`](docs/) for the product, system, database, API, UI/UX, and development specifications.

## Technology stack

- Angular 20, standalone components, strict TypeScript, SCSS
- ASP.NET Core / .NET 8
- MongoDB Atlas with MongoDB.Driver
- REST API under `/api/v1`, documented with Swagger/OpenAPI
- JWT access-token and refresh-token architecture (authentication is not implemented in this foundation)
- RBAC and permission-based authorization (business authorization is not implemented in this foundation)
- Serilog technical logging and MongoDB business audit logging

## Repository structure

```text
docs/                            Product and architecture documentation
src/
  backend/
    Clinora.sln
    src/
      Clinora.Api/               HTTP host, health endpoint, Swagger, middleware
      Clinora.Application/       Application-layer foundation
      Clinora.Domain/            Domain-layer foundation
      Clinora.Infrastructure/    MongoDB configuration and DI foundation
    tests/
      Clinora.UnitTests/
      Clinora.IntegrationTests/
  frontend/
    clinora-web/                 Angular 20 standalone application
```

The foundation intentionally contains no authentication flow or business modules.

## Prerequisites

- .NET 8 SDK
- Node.js version supported by Angular 20 and npm
- Access to a MongoDB Atlas development database when persistence is introduced

## Local setup

Restore and build the backend:

```powershell
dotnet restore .\src\backend\Clinora.sln
dotnet build .\src\backend\Clinora.sln
dotnet test .\src\backend\Clinora.sln
```

Run the API:

```powershell
dotnet run --project .\src\backend\src\Clinora.Api\Clinora.Api.csproj
```

In Development, Swagger UI is available at `/swagger` and the health endpoint is `/api/v1/health`.

Run the Angular application:

```powershell
Set-Location .\src\frontend\clinora-web
npm install
npm start
```

## Configuration

API settings use the standard ASP.NET Core configuration providers. Supply local values through .NET User Secrets or environment variables; do not commit credentials.

Examples of environment-variable names:

- `MongoDB__ConnectionString`
- `MongoDB__DatabaseName`
- `Jwt__Issuer`
- `Jwt__Audience`
- `Jwt__SigningKey`

MongoDB and JWT settings are placeholders only; no database connection or authentication flow is activated by this foundation. Angular configuration must contain only public settings, such as the API base URL.

## Development workflow

1. Read the relevant specifications under `docs/` before implementing a feature.
2. Keep backend dependencies aligned with Clean Architecture and keep controllers/endpoints thin.
3. Enforce tenant scope and permissions on the backend; frontend guards are UX controls only.
4. Use feature-focused tests and validate critical authorization, pharmacist data-boundary, and tenant-isolation behavior.
5. Run the backend build/tests and Angular build for changes affecting those projects.
6. Update API/OpenAPI and relevant documentation when contracts change.

Do not add relational database dependencies, Angular Material without approval, microservices, CQRS, event sourcing, or other premature infrastructure.
