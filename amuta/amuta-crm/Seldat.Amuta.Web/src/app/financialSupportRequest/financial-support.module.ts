import { NgModule } from '@angular/core';
import { FinancialSupportRequestFormComponent } from './financial-support-request-form/financial-support-request-form.component';
import { SharedModule } from '../shared/shared.module';
import { FinancialSupportService } from './shared/services/financial-support.service';
import { FinancialSupportRequestsGridComponent } from './financial-support-requests-grid/financial-support-requests-grid.component';


@NgModule({
  declarations: [
    FinancialSupportRequestFormComponent,
    FinancialSupportRequestsGridComponent, 
  ],
  imports: [
    SharedModule
  ],
  providers: [
    FinancialSupportService
  ],
  exports: [
    FinancialSupportRequestFormComponent, 
]
})
export class FinancialSupportModule { }
