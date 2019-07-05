import { Component, OnInit } from '@angular/core';
import { Student } from '../shared/models/student.model';
import { StudentService } from '../shared/services/student.service';
import { Country } from 'src/app/shared/models/country.model';
import { City } from 'src/app/shared/models/city.model';
import { Street } from 'src/app/shared/models/street.model';
import { Address } from 'src/app/shared/models/address.model';
import { Bank } from 'src/app/shared/models/bank.model';
import { HttpErrorResponse } from '@angular/common/http';
import { StudentChild } from '../shared/models/student-child.model';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-student-form',
  templateUrl: './create-student-form.component.html',
  styleUrls: ['./create-student-form.component.scss']
})
export class CreateStudentFormComponent implements OnInit {


  country: Country = new Country(1);
  city: City = new City(1, '', this.country);
  street: Street = new Street(1);
  address: Address = new Address(1, this.country, this.city, '', this.street);
  bank: Bank = new Bank('', '', '');
  date: Date = new Date(1, 5, 2018);
  i: number;
  index: number;
  children: StudentChild[] = [];
  stud: Student = new Student(100, '', '', '', '', new Address(1, new Country(1), new City(1, '', new Country(1)), '', new Street(1)), new Date(), '', '', '', new Bank('', '', ''), '', 0, 0, '', '', 0, '', 0, '', '', false, this.children);
  id: string;
  kind: string;
  studentId: number;
  isUpdate: boolean;
  constructor(private studentService: StudentService,
     private router: Router,
     private route: ActivatedRoute) { }

  ngOnInit() {

    //how to use the same component in angular using routing each time for different thing
    this.route.data.subscribe(data => {
      this.kind = data.kind;

      this.route.params.subscribe(params => {
        this.studentId = +params['id']; // (+) converts string 'id' to a number
      });
      switch (data.kind) {
        case 'create': {
          //  this.studentService.InsertPendingStudent(this.stud, 1).subscribe((student: Student) => {              
          //    this.stud = student;
          //  },
          //  (error: HttpErrorResponse) => {
          //     alert(error.message)
          //   });
          this.isUpdate = false;
          break;

        }
        case 'update': {
          this.studentService.getStudent(this.studentId).subscribe((student: Student) => {
            this.stud = student;
            this.isUpdate = true;
          },
            (error: HttpErrorResponse) => {
              alert(error.message)
            });
          break;
        }
      }
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });

  }

  AddStudent() {
    this.studentService.InsertPendingStudent(this.stud, 28).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }


  Continue = function () {
    this.router.navigate(['branches/createBranchStudent', this.stud.IdentityNumber]);
  };

  AddChild() {
    let amount = this.stud.ChildrenNumber;
    let now = amount - this.stud.StudentChildren.length;

    if (amount > this.stud.StudentChildren.length) {
      for (let j = 0; j < now; j++)
        this.stud.StudentChildren.push(new StudentChild());
    }
    else {
      this.stud.StudentChildren = this.stud.StudentChildren.splice(0, this.stud.ChildrenNumber);
    }
  }

  update() {
    this.studentService.UpdateStudent(this.stud).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message);
      });
  }
}
