import { Component, OnInit } from '@angular/core';
import { BranchService } from '../../shared/services/branch.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivityHours } from '../../shared/models/activity-hours';
import { TranslateService } from '@ngx-translate/core';
import { Branch } from '../../shared/models/branch.model';

@Component({
  selector: 'app-activity-hours-grid',
  templateUrl: './activity-hours-grid.component.html',
  styleUrls: ['./activity-hours-grid.component.scss']
})
export class ActivityHoursGridComponent implements OnInit {
 
 
  activityHours: ActivityHours[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth:number = 14;
  columnWordsDefs: any[];
  
  constructor(private branchService: BranchService,
    private translate: TranslateService ) { 
     this.translate.get('BRANCHES').subscribe(
       translation => {  
         this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
         this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
         this.initColumnnDefs();
       });
    }


  ngOnInit() {
   
      this.branchService.GetBranchsActivityHoursByBranch(1).subscribe(( activityHours: ActivityHours[]) => {   
        this.activityHours=activityHours;
      },
        (error: HttpErrorResponse) => {
          alert(error.message);
        }); 
     }
  
  initColumnnDefs() {
    this.columnDefs = [ 
      {//סניף
        headerName: this.columnHeaders["BRANCH"],
        headerTooltip: this.columnHeaders["BRANCH"],
        //todo change to name of branch
        valueGetter: (params) => { return (params.data.Branch as Branch).Id},
        tooltip: (params) => { return (params.data.Branch as Branch).Id },
        minWidth: this.columnHeaders["BRANCH"].length * this.wWidth,
        autoHeight: true,
      },   
     {//מאיזה שעה נחשב כאיחור
       headerName: this.columnHeaders["LATE_HOUR"],
       headerTooltip: this.columnHeaders["LATE_HOUR"],
       field: "LateHour",
       tooltipField: 'LateHour',
       minWidth: this.columnHeaders["LATE_HOUR"].length * this.wWidth,
       autoHeight: true,
     },
     {//שעת התחלת הלימוד
       headerName: this.columnHeaders["START_STUDY_HOURS"],
       headerTooltip: this.columnHeaders["START_STUDY_HOURS"],
       field: "StartStudyHours",
       tooltipField: 'StartStudyHours',
       minWidth: this.columnHeaders["START_STUDY_HOURS"].length * this.wWidth + 10,
       autoHeight: true,
     },
     {//שעת סיום הלימוד
      headerName: this.columnHeaders["END_STUDY_HOURS"],
      headerTooltip: this.columnHeaders["END_STUDY_HOURS"],
      field: "EndStudyHours",
      tooltipField: 'EndStudyHours',
      minWidth: this.columnHeaders["END_STUDY_HOURS"].length * this.wWidth + 10,
      autoHeight: true,
    }
    ]
  }
  
}

  
