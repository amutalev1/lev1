import { NgModule } from '@angular/core';
import { HealthSupportRequestFormComponent } from './health-support-request-form/health-support-request-form.component';
import { SharedModule } from '../shared/shared.module';
import { HealthSupportService } from './shared/services/health-support.service';

@NgModule({
  declarations: [
    HealthSupportRequestFormComponent, 
  ],
  imports: [
    SharedModule,
  ],
  providers: [
    HealthSupportService
  ],
  exports: [
    HealthSupportRequestFormComponent, 
]
})
export class HealthSupportModule { }
