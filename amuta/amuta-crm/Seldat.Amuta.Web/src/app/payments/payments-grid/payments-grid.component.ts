import { Component, OnInit } from '@angular/core';
import { Payment } from '../shared/models/payment';
import { TranslateService } from '@ngx-translate/core';
import { PaymentService } from '../shared/services/payment.service';
import { HttpErrorResponse } from '@angular/common/http';
import { StudentService } from 'src/app/students/shared/services/student.service';
import { Student } from 'src/app/students/shared/models/student.model';

@Component({
  selector: 'app-payments-grid',
  templateUrl: './payments-grid.component.html',
  styleUrls: ['./payments-grid.component.scss']
})
export class PaymentsGridComponent implements OnInit {
  payments: Payment[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth: number = 14;
  columnWordsDefs: any[];
  student: Payment;
  branchId: number;
  bottomGridOptions;
  topGridOptions;
  bottomData : any[];
  constructor(
    private paymentService: PaymentService,
    private translate: TranslateService,
    private studentService:StudentService) {
    this.translate.get('PAYMENTS').subscribe(
      translation => {
        this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
        this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
        this.initColumnnDefs();
      });
  }

  ngOnInit() {
    // this.paymentService.getPayments(1).subscribe((payments: Payment[]) => {     
    //     this.payments = payments;
    // },
    //    (error: HttpErrorResponse) => {
    //     alert(error.message)
    //   });
    this.topGridOptions = {alignedGrids: [], suppressHorizontalScroll: true};
    this.bottomGridOptions = {alignedGrids: []}
    this.topGridOptions.alignedGrids.push(this.bottomGridOptions);
    this.bottomGridOptions.alignedGrids.push(this.topGridOptions);

    this.paymentService.getPayments().subscribe((payments: Payment[]) => {
      this.payments = payments;
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  initColumnnDefs() {

    this.columnDefs = [
      {//תלמיד
        headerName: this.columnHeaders["STUDENT"],
        headerTooltip: this.columnHeaders["STUDENT"],
        field: 'Student',
        valueGetter: (params) => {
         // return (this.studentService.getStudent(params.data.Student.Id) as Student).FirstName;
         return params.data.Student.Id;
        },
        tooltipField: 'Student',
        minWidth: this.columnHeaders["STUDENT"].length * this.wWidth
      },
      {//שנה
        headerName: this.columnHeaders["YEAR"],
        headerTooltip: this.columnHeaders["YEAR"],
        field: "Year",
        tooltipField: 'year',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["YEAR"].length * this.wWidth
      },
      {//חודש
        headerName: this.columnHeaders["MONTH"],
        headerTooltip: this.columnHeaders["MONTH"],
        field: 'Month',
        tooltipField: 'Month',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["MONTH"].length * this.wWidth
      },
      {//סכום מלגה
        headerName: this.columnHeaders["PAYMENT_SUM"],
        headerTooltip: this.columnHeaders["PAYMENT_SUM"],
        field: 'PaymentSum',
        tooltipField: 'PaymentSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["PAYMENT_SUM"].length * this.wWidth
      },
      {//סיכום נוכחות
        headerName: this.columnHeaders["ATTENDANCE_SUM"],
        headerTooltip: this.columnHeaders["ATTENDANCE_SUM"],
        field: 'AttendanceSum',
        tooltipField: 'AttendanceSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["ATTENDANCE_SUM"].length * this.wWidth
      },
      {//סכום מבחנים
        headerName: this.columnHeaders["EXAMS_SUM"],
        headerTooltip: this.columnHeaders["EXAMS_SUM"],
        field: 'ExamsSum',
        tooltipField: 'ExamsSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["EXAMS_SUM"].length * this.wWidth
      },     
      {//תקציב מדינה
        headerName: this.columnHeaders["STATE_BUDGET_SUM"],
        headerTooltip: this.columnHeaders["STATE_BUDGET_SUM"],
        field: 'StateBudgetSum',
        tooltipField: 'StateBudgetSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["STATE_BUDGET_SUM"].length * this.wWidth
      },
      {//תמיכה רפואית
        headerName: this.columnHeaders["HEALTH_SUPPORT_SUM"],
        headerTooltip: this.columnHeaders["HEALTH_SUPPORT_SUM"],
        field: 'HealthSupportSum',
        tooltipField: 'HealthSupportSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["HEALTH_SUPPORT_SUM"].length * this.wWidth
      },
      {//טיפולי שיניים
        headerName: this.columnHeaders["DENTAL_HEALTH_SUPPORT_SUM"],
        headerTooltip: this.columnHeaders["DENTAL_HEALTH_SUPPORT_SUM"],
        field: 'DentalHealthSupportSum',
        tooltipField: 'DentalHealthSupportSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["DENTAL_HEALTH_SUPPORT_SUM"].length * this.wWidth
      },     
      {//תמיכה כלכלית 
        headerName: this.columnHeaders["FINANCIAL_SUPPORT_SUM"],
        headerTooltip: this.columnHeaders["FINANCIAL_SUPPORT_SUM"],
        field: 'FinancialSupportSum',
        tooltipField: 'FinancialSupportSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["FINANCIAL_SUPPORT_SUM"].length * this.wWidth
      },
      {//הלוואות שנתנו
        headerName: this.columnHeaders["LOANS_GIVEN_SUM"],
        headerTooltip: this.columnHeaders["LOANS_GIVEN_SUM"],
        field: 'LoansGivenSum',
        tooltipField: 'LoansGivenSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["LOANS_GIVEN_SUM"].length * this.wWidth
      },
      {//החזר הלוואות
        headerName: this.columnHeaders["LOANS_RETURN_SUM"],
        headerTooltip: this.columnHeaders["LOANS_RETURN_SUM"],
        field: 'LoansReturnSum',
        tooltipField: 'LoansReturnSum',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["LOANS_RETURN_SUM"].length * this.wWidth
      },
      {//סיכום
        headerName: this.columnHeaders["SUMMARY"],
        headerTooltip: this.columnHeaders["SUMMARY"],
        valueGetter: (params) => {
          return params.data.PaymentSum-
          params.data.AttendanceSum+
          params.data.ExamsSum+
          params.data.StateBudgetSum+
          params.data.HealthSupportSum+
          params.data.DentalHealthSupportSum+
          params.data.FinancialSupportSum+
          params.data.LoansGivenSum-
          params.data.LoansReturnSum;
        },       
        cellClass: 'number-field',
        minWidth: this.columnHeaders["SUMMARY"].length * this.wWidth
      },
    ];

    this.bottomData = [
      {
          PAYMENT_SUM:0,
         
      }
  ];
  }
}
