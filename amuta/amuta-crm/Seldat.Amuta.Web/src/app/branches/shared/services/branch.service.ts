import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ApiConstants } from 'src/app/shared/api-constants';
import { Observable } from 'rxjs';
import { Branch } from '../models/branch.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  constructor(private http: HttpClient) { }
 
  environment=environment;

  getBranches(typeId: number): Observable<Branch[]> {
    return this.http.get(ApiConstants.GetBranches + "/" + typeId)
      .map((response: Branch[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  getBranch(branchId: number): Observable<Branch> {
    return this.http.get(ApiConstants.GetBranch + "/" + branchId)
      .map((response: Branch) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  makeBranchInactive(branchId: number) {
    return this.http.put(ApiConstants.MakeBranchInactive, branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  makeBranchActive(branchId: number) {
    return this.http.put(ApiConstants.MakeBranchActive, branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  InsertBranch(branch1: Branch): Observable<Branch> {
    alert(branch1.Name);
    return this.http.post(ApiConstants.InsertBranch, branch1)
      .map((response: Branch) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  UpdateBranch(branch: Branch): Observable<Branch> {
    return this.http.put(ApiConstants.UpdateBranch, branch)
      .map((response: Branch) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  ReduceNumberOfStudents(branchId: number) {
    return this.http.put(ApiConstants.ReduceNumberOfStudents, branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  IncreaseNumberOfStudents(branchId: number) {
    return this.http.put(ApiConstants.IncreaseNumberOfStudents, branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }
  GetBranchsActivityHoursByBranch(id: number) {
    return this.http.get(ApiConstants.GetBranchsActivityHoursByBranch + "/" + id)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  Contain(str: string): Observable<Branch[]> {
    return this.http.get(ApiConstants.ContainsBranch + "/" + str)
      .map((response: Branch[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  delete(){
    return this.http.put(ApiConstants.Delete,environment.selected)
    .map((response: Branch) => response) 
    .catch((response: HttpErrorResponse) => Observable.throw(response));   
  }

}5