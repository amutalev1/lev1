import { NgModule } from '@angular/core';
import { StudentService } from './shared/services/student.service';
import { StudentsGridComponent } from './students-grid/students-grid.component';
import { SharedModule } from '../shared/shared.module';
import { CreateStudentFormComponent } from './create-student-form/create-student-form.component';
import { StudentChildrenComponent } from './student-children/student-children.component';
import { CreateBranchStudentFormComponent } from './create-branch-student-form/create-branch-student-form.component';
import { StudentPaymentFormComponent } from './student-payment-form/student-payment-form.component';
import { BranchModule } from '../branches/branch.module';
import { StudentDetailsComponent } from './student-details/student-details.component';





@NgModule({
  declarations: [
    StudentsGridComponent,
    CreateStudentFormComponent,
    StudentChildrenComponent,    
    CreateBranchStudentFormComponent,
    StudentPaymentFormComponent,
    StudentDetailsComponent
  ],
  imports: [
    SharedModule,
    BranchModule
  ],
  providers: [
    StudentService
  ],
  exports: [
   StudentsGridComponent
]
})
export class StudentModule { }
