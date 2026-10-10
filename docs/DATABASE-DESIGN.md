# Clinora — MongoDB Database Design
## Version 1.0

## 1. Database
MongoDB Atlas is used for development and production. No relational database is required for V1.

## 2. Tenant Strategy
Tenant-owned documents should contain `clinicId`. The backend must derive and enforce clinic context from the authenticated session. Never trust a client-supplied clinicId as the only authorization mechanism.

## 3. Core Collections
- Clinics
- Users
- Roles
- Permissions
- RolePermissions
- UserRoles
- RefreshTokens / Sessions
- Patients
- MedicalHistories
- Appointments
- Consultations
- Prescriptions
- PrescriptionItems
- Medicines
- Suppliers
- Purchases
- PurchaseItems
- StockTransactions
- LaboratoryTests
- LaboratoryOrders
- LaboratoryResults
- Invoices
- InvoiceItems
- Payments
- Files
- AuditLogs

Model documents according to MongoDB access patterns; do not blindly mimic SQL tables.

## 4. Common Fields
```json
{
  "_id": "ObjectId",
  "clinicId": "ObjectId",
  "createdAt": "Date",
  "createdBy": "ObjectId",
  "updatedAt": "Date",
  "updatedBy": "ObjectId"
}
```

Use soft deletion only where justified.

## 5. Users
Conceptual fields: clinicId, username, mobile, passwordHash, displayName, roleIds, status, lastLoginAt, timestamps. Never store plaintext passwords.

## 6. Roles and Permissions
Example permission codes:
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

## 7. Patients
Store clinicId, patientNumber, name, contacts, demographics, relevant clinical metadata, timestamps. Sensitive clinical information should have appropriate access boundaries.

## 8. Medical History
Store patientId, clinicId, type, condition/diagnosis, notes, recordedBy, recordedAt. Access is permission-controlled.

## 9. Appointments
patientId, doctorId, appointmentDateTime, duration, status, reason, permitted notes. Index by clinic/date/doctor/patient as needed.

## 10. Consultations
patientId, doctorId, appointmentId, symptoms, diagnosis, clinicalNotes, privateNotes, treatmentPlan, followUpDate. Private notes require stricter permissions.

## 11. Prescriptions
Header: patientId, doctorId, consultationId, status, prescribedAt, finalizedAt. Items: medicineId, medicineName snapshot, dosage, frequency, duration, quantity, instructions.

## 12. Medicines and Stock
Medicine master includes name, genericName, category, unit, sellingRate, tax configuration, reorder level, status. Stock should use transaction/current-inventory modeling appropriate to the workflow.

## 13. Laboratory
Tests, orders, results and reports link to patient and clinic and are permission-controlled.

## 14. Billing
Invoice contains patientId, invoiceNumber, line items, subtotal, discount, tax, total, status, payment status. Lines: medicine/service, quantity, rate, discount, tax, total.

## 15. Payments
invoiceId, amount, method, transactionReference, status, paidAt, recordedBy.

## 16. AuditLogs
Fields: clinicId, actorUserId, action, entityType, entityId, timestamp, metadata, correlationId, result. Do not store passwords/tokens or unnecessary sensitive clinical content.

## 17. Files
MongoDB stores metadata; file content uses an appropriate storage implementation. Metadata includes clinicId, patientId where applicable, fileName, contentType, size, storageKey, uploadedBy, createdAt.

## 18. Indexing
Create indexes based on actual access patterns. Examples:
- clinicId + patientNumber
- clinicId + normalized patient name
- clinicId + appointmentDateTime
- clinicId + doctorId + appointmentDateTime
- clinicId + patientId + prescribedAt
- clinicId + normalized medicine name
- clinicId + timestamp for AuditLogs

Tenant-scoped uniqueness should include clinicId.

## 19. Integrity
Use MongoDB transactions only where multi-document atomicity is truly required. Prefer good document boundaries and idempotent operations.

## 20. Security
Tenant filtering, least privilege, encryption in transit, secure Atlas credentials, no secrets in source control, audit sensitive access.
