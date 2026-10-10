# Clinora — Product Requirements Document (PRD)
## Version 1.0

## 1. Product Overview
Clinora is a modern healthcare management platform for doctors, clinics, hospitals, pharmacists, and healthcare staff. It provides a unified platform for patient management, appointments, consultations, prescriptions, pharmacy, laboratory workflows, billing, reporting, analytics, users, roles, and auditability.

**Tagline:** A smarter way to run modern healthcare.

## 2. Goals
- Centralize healthcare operations in one platform.
- Improve doctor and staff productivity.
- Secure sensitive patient information.
- Reduce manual operational work.
- Enforce least-privilege access.
- Support web first, with future Android/iOS applications.
- Provide dashboards and reports.

## 3. Users
### Doctor / Admin
Full operational access according to configured permissions.

### Pharmacist
Minimum necessary access:
- Patient Name
- Patient ID
- Prescription details
- Prescribed medicines
- Quantity
- Billing information

Must not have unrestricted access to complete medical history, previous diagnoses, doctor private notes, or sensitive consultation information.

## 4. Technology
- Angular 20
- ASP.NET Core / .NET 8 LTS
- MongoDB Atlas
- REST / JSON
- JWT + refresh tokens
- RBAC + permission-based authorization
- Serilog
- MongoDB business AuditLogs
- Responsive mobile-first UI
- Future Android/iOS clients

## 5. Functional Requirements
### Authentication
Username/mobile + password, secure hashing, JWT access token, refresh token, expiry handling, logout, route protection. Future SMS/email OTP and authenticator-app 2FA.

### Clinic / Tenant
Clinic profile, tenant isolation, clinic-specific users/data, configurable settings.

### Patients
Registration, patient ID, demographics, contacts, medical history, allergies, search, profile, documents.

### Appointments
Create, calendar, status, search/filter, reschedule, cancel, daily view.

### Consultations
Symptoms, clinical notes, diagnosis, treatment plan, follow-up, private doctor notes.

### Prescriptions
Create, medicines, dosage/frequency/duration, quantity, instructions, finalize, history subject to permissions.

### Pharmacy
Medicine master, suppliers, purchases, stock intake, adjustments, availability, prescription fulfillment, billing, low-stock.

### Laboratory
Test catalog, orders, sample/status workflow, results, reports, patient-linked history.

### Billing
Line fields: Medicine, Quantity, Rate, Discount, Tax, Total. Support invoices, payments, cancellation/refunds as authorized.

### Dashboard
Today's patients, appointments, prescriptions, revenue, patient activity, pharmacy, laboratory, revenue analytics, recent activity, quick actions.

### Reports
Patient, appointment, prescription, pharmacy/stock, laboratory, billing/revenue reports with authorized export.

### Users / Roles / Permissions
User, role, permission management and mappings.

### Audit
Track patient, prescription, medicine, stock, invoice, payment, user, role/permission and relevant security events.

## 6. Non-Functional Requirements
- Secure by default
- Responsive/mobile-first
- Accessible
- Maintainable modular architecture
- Tenant isolation
- Consistent API errors
- Structured technical logging
- Business auditability
- Automated testing foundation
- Production-ready configuration

## 7. Security
Backend is the security boundary. UI hiding is not authorization. Hash passwords securely. Never log passwords, tokens, or secrets. Enforce tenant isolation and least privilege.
