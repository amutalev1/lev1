import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { PaymentsGridComponent } from './payments-grid/payments-grid.component';
import { PaymentService } from './shared/services/payment.service';

@NgModule({

  declarations: [
    PaymentsGridComponent
  ],
  imports: [
    SharedModule
  ],
  providers:[
    PaymentService
  ],
  exports:[
    PaymentsGridComponent
  ]
})
export class PaymentModule { }
