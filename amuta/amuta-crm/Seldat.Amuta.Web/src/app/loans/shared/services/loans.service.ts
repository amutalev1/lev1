import { Injectable } from '@angular/core';
import { Loans } from '../models/loans';
import { Observable } from 'rxjs';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { ApiConstants } from 'src/app/shared/api-constants';

@Injectable({
  providedIn: 'root'
})
export class LoansService {
 

  constructor(private http: HttpClient) { }

  GetLoans(): Observable<Loans[]>{
    return this.http.get(ApiConstants.GetLoans)
     .map((response: Loans[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }


  
  InsertLoan(loan:Loans): Observable<Loans> {
    alert(loan.Details);
    return this.http.post(ApiConstants.InsertLoan ,loan)
    .map((response: Loans) => response) 
    .catch((response: HttpErrorResponse) => Observable.throw(response));
  }  
}
