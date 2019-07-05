import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ApiConstants } from 'src/app/shared/api-constants';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ExamService {

  constructor(private http: HttpClient) { }
  GetBranchExamsBybranchId(id:number){
    return this.http.get(ApiConstants.GetBranchExamsBybranchId+ "/" +id)
       .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  GetExams(){
    return this.http.get(ApiConstants.GetExams)
       .catch((response: HttpErrorResponse) => Observable.throw(response));
  }
}
