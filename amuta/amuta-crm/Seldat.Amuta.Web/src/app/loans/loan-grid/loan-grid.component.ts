import { Component, OnInit } from '@angular/core';
import { Loans } from '../shared/models/loans';
import { LoansService } from '../shared/services/loans.service';
import { TranslateService } from '@ngx-translate/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Branch } from 'src/app/branches/shared/models/branch.model';
import *  as moment from 'moment';

@Component({
  selector: 'app-loan-grid',
  templateUrl: './loan-grid.component.html',
  styleUrls: ['./loan-grid.component.scss']
})
export class LoanGridComponent implements OnInit {

  loans: Loans[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth:number = 10;
  columnWordsDefs: any[];

  constructor(private loansService: LoansService,
    private translate: TranslateService) {
      this.translate.get('LOANS').subscribe(
        translation => {  
          this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
          this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
          this.initColumnnDefs();
        });
     }

 
    ngOnInit() {
      this.loansService.GetLoans().subscribe((loans: Loans[]) => {   
        this.loans=loans;
      },
        (error: HttpErrorResponse) => {
          alert(error.message);
        }); 
      }
  
      initColumnnDefs(){
        this.columnDefs = [                     
           {//תלמיד
            headerName: this.columnHeaders["STUDENT"],
            headerTooltip: this.columnHeaders["STUDENT"],
            field: "Student",
            valueGetter: (params) => {
              // return (this.studentService.getStudent(params.data.Student.Id) as Student).FirstName;
              return params.data.Student.Id;
             },
            tooltipField: "Student",
            minWidth: this.columnHeaders["STUDENT"].length * this.wWidth,
            autoHeight: true,
           },
           {//כולל
            headerName: this.columnHeaders["BRANCH"],
            headerTooltip: this.columnHeaders["BRANCH"],      
            valueGetter: (params) => { return (params.data.branch as Branch).Id},
            tooltip: (params) => { return (params.data.branch as Branch).Id },
            minWidth: this.columnHeaders["BRANCH"].length * this.wWidth,
            autoHeight: true,
          },
           {//סטטוס נוכחי
             headerName: this.columnHeaders["CURRENT_STATUS"],
             headerTooltip: this.columnHeaders["CURRENT_STATUS"],
             field: "todo",
             tooltipField: 'todo',
             minWidth: this.columnHeaders["CURRENT_STATUS"].length * this.wWidth,
             autoHeight: true,
           },
           {//כמות מבוקשת
            headerName: this.columnHeaders["AMOUNT_REQUESTED"],
            headerTooltip: this.columnHeaders["AMOUNT_REQUESTED"],
            field: "AmountRequested",
            tooltipField: 'AmountRequested',
            minWidth: this.columnHeaders["AMOUNT_REQUESTED"].length * this.wWidth,
            autoHeight: true,
          },
          {//כמות החזר חודשי
            headerName: this.columnHeaders["AMOUNT_REPAYMENT_MONTHLY"],
            headerTooltip: this.columnHeaders["AMOUNT_REPAYMENT_MONTHLY"],
            field: "AmountRepaymentMonthly",
            tooltipField: 'AmountRepaymentMonthly',
            minWidth: this.columnHeaders["AMOUNT_REPAYMENT_MONTHLY"].length * this.wWidth,
            autoHeight: true,
          },
          {//תאריך החזרת כל הסכום
            headerName: this.columnHeaders["DATE_RETURNING_ENTIRE_AMOUNT"],
            headerTooltip: this.columnHeaders["DATE_RETURNING_ENTIRE_AMOUNT"],
            // field: "DateReturningEntireAmount",
            // tooltipField: 'DateReturningEntireAmount',

            tooltip: (params) => {
              return params.data.DateReturningEntireAmount != null ? moment(params.data.BornDate).format('DD/MM/YYYY') : '';
            },
            valueGetter: (params) => {
              return params.data.DateReturningEntireAmount;
            },
            valueFormatter: (params) => {
              return params.data.DateReturningEntireAmount != null ? moment(params.data.BornDate).format('DD/MM/YYYY') : '';
            },
            minWidth: this.columnHeaders["DATE_RETURNING_ENTIRE_AMOUNT"].length * this.wWidth,
            autoHeight: true,
          },
          {//סיבה שאושר
            headerName: this.columnHeaders["REASON_IS_APPROVED"],
            headerTooltip: this.columnHeaders["REASON_IS_APPROVED"],
            field: "ReasonIsApproved",
            tooltipField: 'ReasonIsApproved',
            minWidth: this.columnHeaders["REASON_IS_APPROVED"].length * this.wWidth,
            autoHeight: true,
          },
          {//האם לא אושר סגירת בקשה
            headerName: this.columnHeaders["IS_DISAPPROVED_CLOSED_REQUEST"],
            headerTooltip: this.columnHeaders["IS_DISAPPROVED_CLOSED_REQUEST"],
            field: "IsDisapprovedClosedRequest",
            tooltipField: 'IsDisapprovedClosedRequest',
            minWidth: this.columnHeaders["IS_DISAPPROVED_CLOSED_REQUEST"].length * this.wWidth,
            autoHeight: true,
          },
          {//פרטים
            headerName: this.columnHeaders["DETAILS"],
            headerTooltip: this.columnHeaders["DETAILS"],
            field: "Details",
            tooltipField: 'Details',
            minWidth: this.columnHeaders["DETAILS"].length * this.wWidth,
            autoHeight: true,
          },
          {//תאריך
            headerName: this.columnHeaders["DATE"],
            headerTooltip: this.columnHeaders["DATE"],
            // field: "Date",
            // tooltipField: 'Date',
            tooltip: (params) => {
              return params.data.Date != null ? moment(params.data.BornDate).format('DD/MM/YYYY') : '';
            },
            valueGetter: (params) => {
              return params.data.Date;
            },
            valueFormatter: (params) => {
              return params.data.Date != null ? moment(params.data.BornDate).format('DD/MM/YYYY') : '';
            },
            minWidth: this.columnHeaders["DATE"].length * this.wWidth,
            autoHeight: true,
          },
          {//האם אושר
            headerName: this.columnHeaders["IS_APPROVED"],
            headerTooltip: this.columnHeaders["IS_APPROVED"],
            field: "IsApproved",
            tooltipField: 'IsApproved',
            minWidth: this.columnHeaders["IS_APPROVED"].length * this.wWidth,
            autoHeight: true,
          },
          {//חתימה דיגיטלית
            headerName: this.columnHeaders["DIGITAL_SIGNATURE"],
            headerTooltip: this.columnHeaders["DIGITAL_SIGNATURE"],
            field: "DigitalSignature",
            tooltipField: 'DigitalSignature',
            minWidth: this.columnHeaders["DIGITAL_SIGNATURE"].length * this.wWidth,
            autoHeight: true,
          },
          {//האם בוטל
            headerName: this.columnHeaders["IS_CANCELED"],
            headerTooltip: this.columnHeaders["IS_CANCELED"],
            field: "IsCanceled",
            tooltipField: 'IsCanceled',
            minWidth: this.columnHeaders["IS_CANCELED"].length * this.wWidth,
            autoHeight: true,
          },
          {//כמות חודשים מאושרת
            headerName: this.columnHeaders["NUMBER_APPROVED_MONTHS"],
            headerTooltip: this.columnHeaders["NUMBER_APPROVED_MONTHS"],
            field: "NumberApprovedMonths",
            tooltipField: 'NumberApprovedMonths',
            minWidth: this.columnHeaders["NUMBER_APPROVED_MONTHS"].length * this.wWidth,
            autoHeight: true,
          },
          {//כמות שאושרה
            headerName: this.columnHeaders["APPROVED_AMOUNT"],
            headerTooltip: this.columnHeaders["APPROVED_AMOUNT"],
            field: "ApprovedAmount",
            tooltipField: 'ApprovedAmount',
            minWidth: this.columnHeaders["APPROVED_AMOUNT"].length * this.wWidth,
            autoHeight: true,
          },
          {//האם פעיל
            headerName: this.columnHeaders["IS_ACTIVE"],
            headerTooltip: this.columnHeaders["IS_ACTIVE"],
            field: "IsActive",
            tooltipField: 'IsActive',
            minWidth: this.columnHeaders["IS_ACTIVE"].length * this.wWidth,
            autoHeight: true,
          }
          
        ];
      }
}


