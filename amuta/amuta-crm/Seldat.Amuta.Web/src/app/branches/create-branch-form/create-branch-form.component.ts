import { Component, OnInit } from '@angular/core';
import { Branch } from '../shared/models/branch.model';
import { BranchType } from '../shared/models/branch-type';
import { UserExtraDetails } from 'src/app/shared/models/user-extra-details';
import { Country } from 'src/app/shared/models/country.model';
import { City } from 'src/app/shared/models/city.model';
import { Street } from 'src/app/shared/models/street.model';
import { Address } from 'src/app/shared/models/address.model';
import { Institution } from 'src/app/shared/models/institution';
import { AttendanceRules } from '../shared/models/attendance-rules';
import { ExamRules } from '../shared/models/exam-rules';
import { Scolarship } from '../shared/models/scolarship';
import { BranchService } from '../shared/services/branch.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-branch-form',
  templateUrl: './create-branch-form.component.html',
  styleUrls: ['./create-branch-form.component.scss']
})
export class CreateBranchFormComponent implements OnInit {

  branchType: BranchType = new BranchType(1, 'הלכה', 'בוקר');
  headUser: UserExtraDetails = new UserExtraDetails('20', '207987793', '035797338', '0527174581', 'img', 1, 'אפרת', 'גנויאר', 'e7174581@gmail.com');
  country: Country = new Country(1);
  city: City = new City(1, '', this.country);
  street: Street = new Street(1)
  address: Address = new Address(1, this.country, this.city, '', this.street);
  instetution: Institution = new Institution(1, 'כולל');
  attends: AttendanceRules = new AttendanceRules(1, 7, 10, 10);
  exam: ExamRules = new ExamRules(1, 7, true, 5, 'חורף');
  date: Date = new Date(1, 5, 2018);
  Scolarship: Scolarship = new Scolarship(1, 12);
  branch: Branch = new Branch(1, this.branchType, this.exam, this.attends, this.Scolarship, this.headUser, this.address, '', this.date, 0, '', this.instetution);
  kind: string;
  branchId:number;
  isUpdate:boolean;
  constructor(private branchService: BranchService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.kind = data.kind;
      this.route.params.subscribe(params => {
        this.branchId = +params['id']; // (+) converts string 'id' to a number
      });
      switch (data.kind) {
        case 'create': {
          this.isUpdate = false;
          break;

        }
        case 'update': {
          this.branchService.getBranch(this.branchId).subscribe((branch: Branch) => {
            this.branch = branch;
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

  InsertBranch() {
    this.branchService.InsertBranch(this.branch).subscribe(() => {

    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

}
