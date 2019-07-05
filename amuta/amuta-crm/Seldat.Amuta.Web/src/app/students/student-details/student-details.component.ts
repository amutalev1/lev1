import { Component, OnInit, Input } from '@angular/core';
import { Student } from '../shared/models/student.model';
import { StudentService } from '../shared/services/student.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.scss']
})
export class StudentDetailsComponent implements OnInit {
  @Input() identity: string = "1";
  student: Student;
  show: boolean = false;
  constructor(
    private studentService: StudentService
  ) { }

  ngOnInit() {
    this.studentService.getStudentByIdentityNumber(this.identity).subscribe((student: Student) => {
      this.student = student;
      if (student != null)
        this.show = true;
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

}
