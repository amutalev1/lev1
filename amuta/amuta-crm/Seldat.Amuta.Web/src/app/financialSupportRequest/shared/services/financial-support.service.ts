import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ApiConstants } from 'src/app/shared/api-constants';
import { FinancialSupport } from '../models/financial-support';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FinancialSupportService {

  constructor(private http: HttpClient) { }

  getFinancialSupports(): Observable<FinancialSupport[]> {
    return this.http.get(ApiConstants.GetFinancialSupportRequests)
      .map((response: FinancialSupport[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

}
