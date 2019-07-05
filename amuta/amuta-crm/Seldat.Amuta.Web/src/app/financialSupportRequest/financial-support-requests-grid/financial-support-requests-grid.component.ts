import { Component, OnInit } from '@angular/core';
import { FinancialSupport } from '../shared/models/financial-support';
import { FinancialSupportService } from '../shared/services/financial-support.service';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-financial-support-requests-grid',
  templateUrl: './financial-support-requests-grid.component.html',
  styleUrls: ['./financial-support-requests-grid.component.scss']
})
export class FinancialSupportRequestsGridComponent implements OnInit {

  financialSupports: FinancialSupport[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth: number = 14;
  columnWordsDefs: any[]

  constructor(private financialSupportService: FinancialSupportService,
    private translate: TranslateService,
    private router: Router) {
    this.translate.get('FinancialSupports').subscribe(
      translation => {
        this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
        this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
        this.initColumnnDefs();
      },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  ngOnInit() {
    this.financialSupportService.getFinancialSupports().subscribe((financialSupports: FinancialSupport[]) => {
      this.financialSupports = financialSupports;
    },
    (error: HttpErrorResponse) => {
        alert(error.message)
    });

  }
  initColumnnDefs() {


    this.columnDefs = [
      {

        headerName: this.columnHeaders["DETAILS"],
        headerTooltip: this.columnHeaders["DETAILS"],
        field: 'Details',
        tooltipField: 'Details',
        minWidth: this.columnHeaders["DETAILS"].length * this.wWidth
      }
    ];

  }

}
