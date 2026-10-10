# Clinora — Development Guidelines
## Version 1.0

## 1. Source of Truth
The current product documentation is:
- PRD.md
- SYSTEM-DESIGN.md
- DATABASE-DESIGN.md
- API-DESIGN.md
- UI-UX-DESIGN.md
- DEVELOPMENT-GUIDELINES.md

If implementation conflicts with these documents, stop and resolve the conflict before coding.

## 2. Principles
Clean Architecture, SOLID, separation of concerns, dependency inversion, secure defaults, least privilege, tenant isolation, and appropriate testing.

## 3. Stack Rules
Frontend: Angular 20, standalone components, strict TypeScript, RxJS/signals where appropriate.
Backend: .NET 8 LTS, ASP.NET Core, nullable reference types, async/await.
Database: MongoDB Atlas + MongoDB.Driver.
Logging: Serilog.

Do not introduce SQL Server, EF Core, or Dapper.

## 4. Controllers
Controllers are thin: receive request, bind/validate, call application use case, return response. No complex business rules or direct complex persistence logic.

## 5. Application Layer
Application services/use cases coordinate workflows. Use DTOs at API boundaries. Do not expose persistence models directly.

## 6. Domain
Keep business rules close to the domain. Avoid unnecessary framework dependencies.

## 7. MongoDB
Repositories are focused and tenant-aware. Always enforce clinic/tenant filtering for tenant-owned data. Do not trust client-supplied tenant IDs. Add indexes based on real access patterns.

## 8. Authentication
Secure password hashing, JWT access tokens, refresh tokens, expiry, and appropriate refresh-session invalidation. Never log credentials/tokens.

## 9. Authorization
Use permissions such as:
- patient.read
- patient.create
- patient.update
- consultation.read
- consultation.create
- prescription.create
- pharmacy.read
- pharmacy.stock.update
- billing.create
- billing.read
- users.manage

Backend authorization is mandatory. Frontend guards/directives are UX controls, not security boundaries.

## 10. Pharmacist Principle
Use minimum necessary access. Do not return restricted patient history or doctor-private information simply because it exists in the same patient record. Prefer purpose-specific DTOs/endpoints.

## 11. Validation
Validate at API boundaries and business/application level where required. Never rely only on Angular validation.

## 12. Errors
Use centralized exception handling. Return safe production errors and log technical details server-side.

## 13. Logging
Serilog for technical logs; MongoDB AuditLogs for business audit. Never log passwords, tokens, API keys, or unnecessary sensitive patient data.

## 14. Angular
Keep components focused, centralize auth/API handling, use guards/interceptors, permission-aware UI, and explicit loading/error/empty states. Avoid deeply nested subscriptions.

## 15. UI
Follow the premium dark Clinora design. Do not introduce Angular Material unless explicitly approved. Use reusable design-system components.

## 16. Testing
Unit test business rules and application services. Integration test authentication, authorization, tenant isolation and critical APIs. Test critical Angular services/components/workflows.

## 17. Configuration
Never commit secrets. Separate development/test/production configuration. Never hard-code MongoDB connection strings, JWT secrets, API keys or cloud credentials.

## 18. Git
Recommended:
- main
- feature/project-scaffold
- feature/authentication
- feature/patients
- feature/appointments
- feature/consultations
- feature/prescriptions
- feature/pharmacy
- feature/laboratory
- feature/billing

Examples:
- chore: initialize Clinora project scaffold
- feat: add authentication foundation
- feat: add patient management
- fix: correct tenant authorization
- refactor: simplify prescription application service
- test: add authorization integration tests

## 19. PR Checklist
Build passes, tests pass, no secrets, authorization checked, tenant isolation checked, errors/logging reviewed, Swagger updated, documentation updated.

## 20. Security Checklist
HTTPS, secure password hashing, JWT validation, refresh-token protection, RBAC/permissions, tenant isolation, validation, safe errors, secure configuration, dependency updates.

## 21. Feature Sequence
1. Repository/docs baseline
2. Scaffold
3. Configuration
4. MongoDB Atlas
5. Exception handling
6. Serilog
7. Swagger
8. Authentication
9. Authorization + tenant context
10. Angular shell
11. Patients
12. Appointments
13. Consultations
14. Prescriptions
15. Pharmacy
16. Laboratory
17. Billing
18. Dashboard
19. Reports
20. Hardening/testing/deployment

## 22. No Premature Complexity
Do not introduce microservices, event buses, Kubernetes, distributed tracing platforms, complex caching, CQRS, or event sourcing unless an actual requirement justifies them. V1 is a maintainable modular monolith.
