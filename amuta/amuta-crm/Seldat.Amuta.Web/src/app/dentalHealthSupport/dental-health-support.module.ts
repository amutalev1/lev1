import { NgModule } from '@angular/core';
import { DentalHealthSupportRequestFormComponent } from './dental-health-support-request-form/dental-health-support-request-form.component';
import { SharedModule } from '../shared/shared.module';
import { DentalHealthSupportService } from './shared/services/dental-health-support.service';



@NgModule({
  declarations: [
    DentalHealthSupportRequestFormComponent, 
  ],
  imports: [
    SharedModule,
  ],
  providers: [
     DentalHealthSupportService
  ],
  exports: [
    DentalHealthSupportRequestFormComponent, 
]
})
export class DentalHealthSupportModule { }
