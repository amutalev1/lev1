import { NgModule } from '@angular/core';
import { ExamsGridComponent } from './exams-grid/exams-grid.component';
import { SharedModule } from '../shared/shared.module';
import { ExamService } from './shared/services/exam.service';

@NgModule({
    declarations: [
        ExamsGridComponent
    ],
    imports: [
        SharedModule
    ],
    providers: [
        ExamService
    ],
    exports: [
        ExamsGridComponent
  ]
  })
  export class ExamModule { }
