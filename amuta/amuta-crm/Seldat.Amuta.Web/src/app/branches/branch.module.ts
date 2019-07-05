import { NgModule } from '@angular/core';
import { BranchesGridComponent } from './branches-grid/branches-grid.component';
import { SharedModule } from '../shared/shared.module';
import { BranchService } from './shared/services/branch.service';
import { ActivityHoursGridComponent } from './activityHours/activity-hours-grid/activity-hours-grid.component';
import { CreateBranchFormComponent } from './create-branch-form/create-branch-form.component';
import { BranchDetailsComponent } from './branch-details/branch-details.component';


@NgModule({
  declarations: [
    BranchesGridComponent,
    ActivityHoursGridComponent,
    CreateBranchFormComponent,
    BranchDetailsComponent
  ],
  imports: [
    SharedModule
  ],
  providers: [
    BranchService,
    BranchesGridComponent
  ],
  exports: [
    BranchesGridComponent,
    BranchDetailsComponent
]
})
export class BranchModule { }
