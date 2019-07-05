import { Injectable } from '@angular/core';
import { Payment } from '../models/payment';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConstants } from 'src/app/shared/api-constants';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  payments: Payment[];
  constructor(private http: HttpClient) { }
  // getStudentPayment(studentId: number): Observable<Payment[]> {
  //   return this.http.get(ApiConstants.getPayment + "/" + studentId)
  //     .map((response: Payment[]) => response)
  //     .catch((response: HttpErrorResponse) => Observable.throw(response));
  // }

  getPayments(): Observable<Payment[]> {
    return this.http.get(ApiConstants.GetPayments)
      .map((response: Payment[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }
}
