# Clinora — UI/UX Design Specification
## Version 1.0

## 1. Personality
Trustworthy, intelligent, calm, premium, human, modern.

Avoid generic hospital website aesthetics, old-fashioned Bootstrap dashboards, excessive glassmorphism, neon colors, clutter, and traditional oversized medical-cross branding.

## 2. Visual Direction
Full dark premium healthcare SaaS:
- Deep charcoal / near-black background
- Dark graphite surfaces
- Warm white / ivory text
- Muted warm amber/bronze accent
- Muted sage green secondary accent

## 3. Typography
Preferred: Manrope, Inter, Plus Jakarta Sans, or DM Sans.

## 4. Landing Page
Tagline: **A smarter way to run modern healthcare.**

Sections:
1. Navigation
2. Hero
3. Connected healthcare
4. Product experience
5. Role-based experience
6. Security
7. Analytics
8. CTA
9. Footer

Hero combines healthcare photography with a stylized product dashboard.

## 5. Login
Premium split-screen:
- Healthcare/product visual
- Clean login panel
- Username/mobile
- Password
- Forgot password
- Sign in
- Future OTP/2FA support

## 6. Application Shell
Desktop: collapsible left sidebar, top header, main content.
Mobile: compact navigation/drawer/bottom navigation as appropriate.

## 7. Navigation
- Overview
- Patients
- Appointments
- Consultations
- Prescriptions
- Pharmacy
- Laboratory
- Billing
- Reports
- Users & Roles
- Settings
- Help

Navigation is permission-aware.

## 8. Header
Greeting, global search, current date/context, notifications, profile, role/context.

## 9. Dashboard
KPI cards for today's patients, appointments, prescriptions, revenue. Include appointment list, patient activity, pharmacy, laboratory, revenue analytics, recent activity and quick actions. Adapt to role.

## 10. Patient Experience
List: search, filters, ID, name, contact, status, last activity.
Profile: summary, appointments, consultations, medical history, prescriptions, labs, billing, documents. Only permitted sections appear.

## 11. Appointment Experience
Calendar/list, today/upcoming, status badges, doctor filter, search, create/reschedule/cancel.

## 12. Consultation
Focused clinical workspace: patient context, symptoms, diagnosis, notes, treatment, follow-up, prescription creation. Private notes have clear access boundaries.

## 13. Prescription
Medicine search, dosage, frequency, duration, quantity, instructions, review, finalize.

## 14. Pharmacy
Medicine search, stock, low stock, purchases, adjustments, fulfillment and billing. Pharmacist UI must not expose restricted clinical information.

## 15. Laboratory
Test catalog, orders, pending samples, results, reports.

## 16. Billing
Invoice workflow with Medicine, Quantity, Rate, Discount, Tax, Total. Show subtotal, discount, tax, grand total and payment status.

## 17. Feedback
Toasts, inline validation, confirmation dialogs, empty states, loading skeletons, error states and retry actions.

## 18. Accessibility
Keyboard navigation, visible focus, adequate contrast, semantic HTML, accessible labels and screen-reader-friendly controls. Never use color alone for status.

## 19. Responsive Design
Mobile-first. Tables should transform into cards or controlled horizontal scrolling. Forms must remain usable on small screens.

## 20. Design System
Reusable buttons, inputs, selects, cards, tables, modals, toasts, badges, tabs, pagination, skeletons, empty/error states. Avoid duplicate styling and one-off components.
