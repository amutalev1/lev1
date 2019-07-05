import { Component, OnInit } from '@angular/core';
import { Loans } from '../shared/models/loans';
import { LoansService } from '../shared/services/loans.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-loans-request-form',
  templateUrl: './loans-request-form.component.html',
  styleUrls: ['./loans-request-form.component.scss']
})
export class LoansRequestFormComponent implements OnInit {

  loan:Loans=new Loans();
  constructor(private LoanService:LoansService) { }

  ngOnInit() {
  }

  AddStudent(){
    this.LoanService.InsertLoan(this.loan).subscribe(() => {      
    },
    (error: HttpErrorResponse) => {
           alert(error.message)
      });

  }

}
