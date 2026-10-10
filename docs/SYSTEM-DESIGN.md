# Clinora — System Design
## Version 1.0

## 1. Architecture
Clinora uses a **Modular Monolith with Clean Architecture principles**.

```text
Angular Web
    ↓
ASP.NET Core API
    ↓
Application
    ↓
Domain

Infrastructure → implements persistence/external infrastructure
```

## 2. Backend
### Clinora.Api
Controllers, HTTP concerns, middleware, DI, auth configuration, Swagger, CORS, health checks.

### Clinora.Application
Use cases, application services, DTOs, interfaces, validation, business orchestration.

### Clinora.Domain
Domain entities, value objects, enums, domain rules, domain abstractions.

### Clinora.Infrastructure
MongoDB, repositories, JWT/token infrastructure, password hashing, file storage, external services, technical logging.

## 3. Angular
```text
src/app/
├── core/
│   ├── auth/
│   ├── guards/
│   ├── interceptors/
│   ├── services/
│   ├── models/
│   └── config/
├── shared/
│   ├── components/
│   ├── directives/
│   ├── pipes/
│   ├── models/
│   └── utils/
├── layout/
│   ├── shell/
│   ├── sidebar/
│   ├── header/
│   └── footer/
└── features/
    ├── dashboard/
    ├── patients/
    ├── appointments/
    ├── consultations/
    ├── prescriptions/
    ├── pharmacy/
    ├── laboratory/
    ├── billing/
    ├── reports/
    ├── users/
    └── settings/
```

## 4. Authentication
V1: username/mobile + password → secure password verification → JWT access token + refresh token → interceptor → refresh on expiry → logout/session invalidation.

Future: SMS/email OTP and authenticator-app 2FA.

## 5. Authorization
Use RBAC plus permissions. Every protected backend operation checks authentication, tenant context, role/permission, and resource restrictions where required.

## 6. Pharmacist Boundary
Purpose-specific DTOs/endpoints should expose only minimum necessary prescription/patient/billing data. Never rely on Angular alone to hide sensitive fields.

## 7. Database
MongoDB Atlas is authoritative. No SQL Server, Entity Framework, or Dapper. Use MongoDB.Driver behind infrastructure abstractions.

## 8. Logging
Technical logs: Serilog. Business audit logs: MongoDB AuditLogs. Never log passwords, tokens, secrets, or unnecessary clinical data.

## 9. Error Handling
Global exception middleware returns safe errors. Production responses must not expose stack traces or internal database details.

## 10. API
REST/JSON, DTOs, validation, pagination, authorization, tenant scoping, Swagger/OpenAPI.

## 11. Files
Use a file-storage abstraction. Local storage can be used in development; production can use cloud object storage.

## 12. Testing
Unit, integration, authorization, tenant-isolation, critical workflow, Angular service/component tests.

## 13. Future Mobile
Android/iOS clients consume the same REST API. Business rules remain server-side.
