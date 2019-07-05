import { Component, OnInit } from '@angular/core';
import { StudentPayment } from '../shared/models/student-payment';
import { StudentService } from '../shared/services/student.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-student-payment-form',
  templateUrl: './student-payment-form.component.html',
  styleUrls: ['./student-payment-form.component.scss']
})
export class StudentPaymentFormComponent implements OnInit {

  constructor(private studentService: StudentService) { }          
  date:Date;
  studentPayment:StudentPayment=new StudentPayment();
  ngOnInit() {
      
  }
  AddStudentPayment(){
    this.studentPayment.Month=new Date(this.date).getMonth();
    this.studentPayment.Year=new Date(this.date).getFullYear();
    this.studentService.InsertStudentPayment(this.studentPayment).subscribe(() => {      
    },
    (error: HttpErrorResponse) => {
        alert(error.message)
    });
  }
}
