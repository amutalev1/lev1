import { Component, OnInit } from '@angular/core';
import { BranchStudent } from '../shared/models/branch-student';
import { Student } from '../shared/models/student.model';
import { Branch } from 'src/app/branches/shared/models/branch.model';
import { StudentService } from '../shared/services/student.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Country } from 'src/app/shared/models/country.model';
import { City } from 'src/app/shared/models/city.model';
import { Street } from 'src/app/shared/models/street.model';
import { Address } from 'src/app/shared/models/address.model';
import { Bank } from 'src/app/shared/models/bank.model';
import { StudentChild } from '../shared/models/student-child.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-branch-student-form',
  templateUrl: './create-branch-student-form.component.html',
  styleUrls: ['./create-branch-student-form.component.scss']
})
export class CreateBranchStudentFormComponent implements OnInit {

  
country:Country=new Country(1);
city:City=new City(1,'',this.country);
street:Street=new Street(1)
address:Address=new Address(1,this.country,this.city,'',this.street);
bank:Bank=new Bank('','','');
date:Date=new Date(1,5,2018);
children:StudentChild[]=[];


  // branch:Branch=new Branch();
  branchStudent:BranchStudent=new BranchStudent(
      new Student(1,'','','','',this.address,this.date,'','','',this.bank,'',0,0,'','',0,'',0,'','',false,this.children)
      ,new Branch(0)
  );
  constructor(private studentService:StudentService,
    private route: ActivatedRoute) { }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.branchStudent.Student.IdentityNumber = params['id']; 
   });
  }
 
 
  AddBranchStudent(){
    this.studentService.RequestRegistrationBranchStudent(this.branchStudent).subscribe(() => {      
    },
    (error: HttpErrorResponse) => {
           alert(error.message)
      });
  }

}
