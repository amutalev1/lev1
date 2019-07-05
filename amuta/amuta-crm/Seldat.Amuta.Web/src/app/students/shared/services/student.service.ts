import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ApiConstants } from 'src/app/shared/api-constants';
import { BranchStudent } from '../models/branch-student';
import { StudentPayment } from '../models/student-payment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  students: Student[];
  constructor(private http: HttpClient) { }

  getStudents(from: number = null, amount: number = null): Observable<Student[]> {
    return this.http.get((from != null && amount != null) ? ApiConstants.getStudents + "/" + from + "/" + amount : ApiConstants.getStudents)
      .map((response: Student[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  getStudentsOfBranch(branchId: number) {
    return this.http.get(ApiConstants.getStudentsOfBranch + "/" + branchId)
      .map((response: Student[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }


  SetStudentInactive(studentId: number) {
    return this.http.delete(ApiConstants.setStudentInactive + "/" + studentId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  SetStudentActive(studentId: number, branchId: number) {
    return this.http.put(ApiConstants.setStudentActive + "/" + studentId, branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  setStudentInactiveInBranch(studentId: number, branchId: number) {
    return this.http.delete(ApiConstants.setStudentInactiveInBranch + "/" + studentId + "/" + branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  setStudentActiveInBranch(studentId: number, branchId: number) {
    return this.http.put(ApiConstants.setStudentActiveInBranch + "/" + studentId, branchId)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  getStudent(studentId: number): Observable<Student> {
    return this.http.get(ApiConstants.getStudent + "/" + studentId)
      .map((response: Student) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  getStudentByIdentityNumber(studentIdentityNumber: string): Observable<Student> {
    return this.http.get(ApiConstants.getStudentByIdentityNumber + "/" + studentIdentityNumber)
      .map((response: Student) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  InsertPendingStudent(student: Student, branchId: number): Observable<Student> {
    alert(student.FirstName);
    return this.http.post(ApiConstants.InsertPendingStudent + "/" + branchId, student)
      .map((response: Student) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  InsertStudentPayment(studentPayment: StudentPayment): Observable<Student> {
    return this.http.post(ApiConstants.InsertStudentPayment, studentPayment)
      .map((response: Student) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  getPendingStudents(): Observable<Student[]> {
    return this.http.get(ApiConstants.getPendingStudents)
      .map((response: Student[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }
  approvalRegistration(branchStudent: BranchStudent) {
    return this.http.put(ApiConstants.approvalRegistration, branchStudent)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }
  RequestRegistrationBranchStudent(branchstudent: BranchStudent): Observable<BranchStudent> {
    alert(branchstudent.Student.Id);
    return this.http.post(ApiConstants.RequestRegistrationBranchStudent, branchstudent)
      .map((response: BranchStudent) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  UpdateStudent(Student: Student): Observable<BranchStudent> {
    return this.http.put(ApiConstants.updateStudent, Student)
      .map((response: BranchStudent) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

  Contain(str: string): Observable<Student[]> {
    return this.http.get(ApiConstants.ContainsStudent + "/" + str)
      .map((response: Student[]) => response)
      .catch((response: HttpErrorResponse) => Observable.throw(response));
  }

}