import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';
import { ExamService } from '../shared/services/exam.service';
import { Exam } from '../shared/models/exam';
import { Branch } from 'src/app/branches/shared/models/branch.model';

@Component({
  selector: 'app-exams-grid',
  templateUrl: './exams-grid.component.html',
  styleUrls: ['./exams-grid.component.scss']
})
export class ExamsGridComponent implements OnInit {
  
  exams: Exam[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth:number = 10;
  columnWordsDefs: any[];


  constructor(private examService: ExamService,
    private translate: TranslateService,
      ) { 
     this.translate.get('EXAMS').subscribe(
       translation => {  
         this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
         this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
         this.initColumnnDefs();
       });
    }

  ngOnInit() {
    this.examService.GetExams().subscribe((exams:Exam[]) => {   
      this.exams=exams;
    },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }); 
    }
  
  
  initColumnnDefs(){
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
       {//ציון להעלאה במלגה
        headerName: this.columnHeaders["SUBMIT_EXAM_SCHROLARSHIP_ADDITION"],
        headerTooltip: this.columnHeaders["SUBMIT_EXAM_SCHROLARSHIP_ADDITION"],
        field: "SumbitExamScholarshipAddition",
        tooltipField: 'SumbitExamScholarshipAddition',
        minWidth: this.columnHeaders["SUBMIT_EXAM_SCHROLARSHIP_ADDITION"].length * this.wWidth,
        autoHeight: true,
       },
       {//ציון להורדה במלגה
        headerName: this.columnHeaders["FAILING_SUBMIT_EXAM_SCHROLARSHIP_REDUCING"],
         headerTooltip: this.columnHeaders["FAILING_SUBMIT_EXAM_SCHROLARSHIP_REDUCING"],
         field: "FailingSumbitExamScholarshipReducing",
         tooltipField: 'FailingSumbitExamScholarshipReducing',
         minWidth: this.columnHeaders["FAILING_SUBMIT_EXAM_SCHROLARSHIP_REDUCING"].length * this.wWidth,
         autoHeight: true,
       },
       {//ציון עובר לתוספת במלגה
        headerName: this.columnHeaders["PASSED_EXAM_SCHOLARSHIP_ADDITION"],
        headerTooltip: this.columnHeaders["PASSED_EXAM_SCHOLARSHIP_ADDITION"],
        field: "PassedExamScholarshipAddition",
        tooltipField: 'PassedExamScholarshipAddition',
        minWidth: this.columnHeaders["PASSED_EXAM_SCHOLARSHIP_ADDITION"].length * this.wWidth,
        autoHeight: true,
      },
      {//ציון לא עובר הורדה במלגה
        headerName: this.columnHeaders["NOT_PASSED_EXAM_SCHOLARSHIP_REDUCING"],
        headerTooltip: this.columnHeaders["NOT_PASSED_EXAM_SCHOLARSHIP_REDUCING"],
        field: "NotPassedExamScholarshipReducing",
        tooltipField: 'NotPassedExamScholarshipReducing',
        minWidth: this.columnHeaders["NOT_PASSED_EXAM_SCHOLARSHIP_REDUCING"].length * this.wWidth,
        autoHeight: true,
      },
      {//ציון עובר
        headerName: this.columnHeaders["PASS_GRADE"],
        headerTooltip: this.columnHeaders["PASS_GRADE"],
        field: "PassGrade",
        tooltipField: 'PassGrade',
        minWidth: this.columnHeaders["PASS_GRADE"].length * this.wWidth,
        autoHeight: true,
      },
      {//נושא
        headerName: this.columnHeaders["SUBJECT"],
        headerTooltip: this.columnHeaders["SUBJECT"],
        field: "Subject",
        tooltipField: 'Subject',
        minWidth: this.columnHeaders["SUBJECT"].length * this.wWidth,
        autoHeight: true,
      }
    ];
  }

}