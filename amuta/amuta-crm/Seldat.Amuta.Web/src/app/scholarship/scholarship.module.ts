import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ScholarshipService } from './shared/services/scholarship.service';
import { ScholarshipRequestFormComponent } from './scholarship-request-form/scholarship-request-form.component';

@NgModule({
  declarations: [
    ScholarshipRequestFormComponent
  ],
  imports: [
    SharedModule
  ],
  providers: [
    ScholarshipService
  ],
  exports: [
    ScholarshipRequestFormComponent
]
})
export class ScholarshipModule { }
