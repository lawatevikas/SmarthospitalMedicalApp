# Clinora — API Design / Contract
## Version 1.0

## 1. Principles
REST, JSON, HTTPS in production, DTOs, validation, consistent errors, pagination, authorization, tenant isolation, Swagger/OpenAPI.

Base path:
`/api/v1`

## 2. Success Response
```json
{
  "success": true,
  "data": {},
  "message": "Operation completed successfully",
  "correlationId": "..."
}
```

## 3. Error Response
```json
{
  "success": false,
  "error": {
    "code": "VALIDATION_ERROR",
    "message": "One or more validation errors occurred.",
    "details": []
  },
  "correlationId": "..."
}
```

Never expose stack traces or internal database details.

## 4. Authentication
- POST `/auth/login`
- POST `/auth/refresh`
- POST `/auth/logout`
- GET `/auth/me`

Login accepts username/mobile + password and returns access token, refresh token, expiry and permitted user context.

## 5. Clinics
- GET `/clinics/current`
- PUT `/clinics/current`

## 6. Users / Roles / Permissions
- GET/POST/GET-by-id/PUT `/users`
- POST `/users/{id}/roles`
- GET/POST/PUT `/roles`
- GET `/permissions`

## 7. Patients
- GET `/patients`
- POST `/patients`
- GET `/patients/{id}`
- PUT `/patients/{id}`
- DELETE `/patients/{id}`

Support search by patient number, name, mobile and status.

## 8. Medical History
- GET `/patients/{patientId}/medical-history`
- POST `/patients/{patientId}/medical-history`
- PUT `/medical-history/{id}`

## 9. Appointments
- GET `/appointments`
- POST `/appointments`
- GET `/appointments/{id}`
- PUT `/appointments/{id}`
- POST `/appointments/{id}/cancel`
- POST `/appointments/{id}/reschedule`

## 10. Consultations
- POST `/consultations`
- GET `/consultations/{id}`
- PUT `/consultations/{id}`
- GET `/patients/{patientId}/consultations`

## 11. Prescriptions
- POST `/prescriptions`
- GET `/prescriptions/{id}`
- PUT `/prescriptions/{id}`
- POST `/prescriptions/{id}/finalize`
- GET `/patients/{patientId}/prescriptions`

Pharmacist workflows must use minimum-necessary DTOs.

## 12. Pharmacy
- GET/POST/PUT `/medicines`
- GET `/stock`
- POST `/stock/receipts`
- POST `/stock/adjustments`
- GET/POST `/suppliers`

## 13. Laboratory
- GET/POST `/laboratory/tests`
- POST `/laboratory/orders`
- GET `/laboratory/orders/{id}`
- POST `/laboratory/results`
- GET `/patients/{patientId}/laboratory`

## 14. Billing
- POST `/billing/invoices`
- GET `/billing/invoices/{id}`
- POST `/billing/invoices/{id}/cancel`
- POST `/billing/payments`
- POST `/billing/payments/{id}/refund`

Invoice lines support Medicine, Quantity, Rate, Discount, Tax, Total.

## 15. Dashboard
- GET `/dashboard/summary`
- GET `/dashboard/appointments`
- GET `/dashboard/patient-activity`
- GET `/dashboard/pharmacy`
- GET `/dashboard/laboratory`
- GET `/dashboard/revenue`

## 16. Reports
Use POST search endpoints where filtering becomes complex:
- `/reports/patients/search`
- `/reports/appointments/search`
- `/reports/pharmacy/search`
- `/reports/laboratory/search`
- `/reports/billing/search`

## 17. Files
- POST `/files`
- GET `/files/{id}`
- DELETE `/files/{id}`

## 18. Audit
- GET `/audit-logs`
- GET `/audit-logs/{id}`

## 19. Authorization
Every protected endpoint evaluates authentication, tenant context, role/permission, and resource-level restrictions where needed. Frontend guards are not security boundaries.

## 20. Validation and Pagination
Validate required fields, formats, ranges, enums and business constraints. Use page/pageSize/sortBy/sortDirection with a safe maximum page size.

## 21. Status Codes
200, 201, 204, 400, 401, 403, 404, 409, 422 where useful, 500.

## 22. Versioning
Start with `/api/v1` and avoid breaking changes within a major version.
