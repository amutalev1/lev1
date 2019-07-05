import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentsGridComponent } from './students/students-grid/students-grid.component';
import { HomeComponent } from './home/home.component';
import { BranchesGridComponent } from './branches/branches-grid/branches-grid.component';
import { PaymentsGridComponent } from './payments/payments-grid/payments-grid.component';
import { ExamsGridComponent } from './exams/exams-grid/exams-grid.component';
import { ActivityHoursGridComponent } from './branches/activityHours/activity-hours-grid/activity-hours-grid.component';
import { CreateStudentFormComponent } from './students/create-student-form/create-student-form.component';
import { DentalHealthSupportRequestFormComponent } from './dentalHealthSupport/dental-health-support-request-form/dental-health-support-request-form.component';
import { HealthSupportRequestFormComponent } from './healthSupport/health-support-request-form/health-support-request-form.component';
import { FinancialSupportRequestFormComponent } from './financialSupportRequest/financial-support-request-form/financial-support-request-form.component';
import { LoansRequestFormComponent } from './loans/loans-request-form/loans-request-form.component';
import { ScholarshipRequestFormComponent } from './scholarship/scholarship-request-form/scholarship-request-form.component';
import { LoanGridComponent } from './loans/loan-grid/loan-grid.component';
import { CreateBranchStudentFormComponent } from './students/create-branch-student-form/create-branch-student-form.component';

import { CreateBranchFormComponent } from './branches/create-branch-form/create-branch-form.component';
import { StudentPaymentFormComponent } from './students/student-payment-form/student-payment-form.component';
import { RequestsComponent } from './requests/requests.component';
import { FinancialSupportRequestsGridComponent } from './financialSupportRequest/financial-support-requests-grid/financial-support-requests-grid.component';


const routes: Routes = [
  {
    path: "students"
    , children: [
      { path: 'allStudents', component: StudentsGridComponent, data: { kind: 'allStudents' } },
      { path: 'create', component: CreateStudentFormComponent, data: { kind: 'create' } },
      { path: 'update/:id', component: CreateStudentFormComponent, data: { kind: 'update' } },
      { path: 'pendingStudents', component: StudentsGridComponent, data: { kind: 'pendingStudents' } },
      { path: 'branchStudents/:id', component: StudentsGridComponent, data: { kind: 'branchStudents' } },
      { path: "studentPayment", component: StudentPaymentFormComponent },
    ]
  },
  {
    path: "branches"
    , children: [
      { path: 'allBranches', component: BranchesGridComponent, data: { kind: 'allBranches' } },
      { path: 'create', component: CreateBranchFormComponent, data: { kind: 'create' } },
      { path: 'update/:id', component: CreateBranchFormComponent, data: { kind: 'update' } },
      { path: "createBranchStudent/:id", component: CreateBranchStudentFormComponent },
      { path: "branchActivityHours/:id", component: ActivityHoursGridComponent },
    ]
  },
  { path: "requests", component: RequestsComponent },
  { path: "financialSupports", component: FinancialSupportRequestsGridComponent },
  // { path: "createBranch", component: CreateBranchFormComponent },
  // { path: "createBranchStudent/:id", component: CreateBranchStudentFormComponent },
  // { path: "branches", component: BranchesGridComponent },
  // { path: "studentpayments/:id", component: PaymentsGridComponent },
  { path: "Exams", component: ExamsGridComponent },
  // { path: "branchActivityHours/:id", component: ActivityHoursGridComponent },
  { path: "financialSupportRequestForm", component: FinancialSupportRequestFormComponent },
  { path: "dentalHealthSupportRequestForm", component: DentalHealthSupportRequestFormComponent },
  { path: "healthSupportRequestForm", component: HealthSupportRequestFormComponent },
  { path: "loansForm", component: LoansRequestFormComponent },
  { path: "scholarshipForm", component: ScholarshipRequestFormComponent },
  { path: "loans", component: LoanGridComponent },
  { path: "payments/allPayments", component: PaymentsGridComponent },
  //temporary till there is links
  { path: "home", component: HomeComponent },
  { path: "home1", component: HomeComponent },
  { path: "home2", component: HomeComponent },
  { path: "home3", component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
