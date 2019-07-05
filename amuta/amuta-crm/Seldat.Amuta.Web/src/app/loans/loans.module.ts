import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { LoansRequestFormComponent } from './loans-request-form/loans-request-form.component';
import { LoansService } from './shared/services/loans.service';
import { FormsModule } from '@angular/forms';
import { LoanGridComponent } from './loan-grid/loan-grid.component';


@NgModule({
  declarations: [
    LoansRequestFormComponent,
    LoanGridComponent
  ],
  imports: [
    SharedModule,
  ],
  providers: [
    LoansService
  ],
  exports: [
    LoansRequestFormComponent
]
})
export class LoansModule { }
