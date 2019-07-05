import { Component, OnInit } from '@angular/core';
import { BranchService } from '../shared/services/branch.service';
import { TranslateService } from '@ngx-translate/core';
import { Branch } from '../shared/models/branch.model';
import { HttpErrorResponse } from '@angular/common/http';
import { UserExtraDetails } from '../../shared/models/user-extra-details';
import *  as moment from 'moment';
import { Address } from '../../shared/models/address.model';
import { BranchType } from '../shared/models/branch-type';
import { ExamRules } from '../shared/models/exam-rules';
import { Country } from 'src/app/shared/models/country.model';
import { City } from 'src/app/shared/models/city.model';
import { Street } from 'src/app/shared/models/street.model';
import { Institution } from 'src/app/shared/models/institution';
import { AttendanceRules } from '../shared/models/attendance-rules';
import { Router } from '@angular/router';
import { Scolarship } from '../shared/models/scolarship';
import { environment } from 'src/environments/environment';
import { SharedService } from 'src/app/shared/services/shared.service';

@Component({
  selector: 'app-branches-grid',
  templateUrl: './branches-grid.component.html',
  styleUrls: ['./branches-grid.component.scss']
})
export class BranchesGridComponent implements OnInit {


  branches: Branch[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth: number = 14;
  columnWordsDefs: any[];

  selectedBranches:Branch[];
  branchType: BranchType = new BranchType(1, 'הלכה', 'בוקר');
  headUser: UserExtraDetails = new UserExtraDetails('20', '207987793', '035797338', '0527174581', 'img', 1, 'אפרת', 'גנויאר', 'e7174581@gmail.com');
  country: Country = new Country(1, 'ישראל', 'י-ל', 123);
  city: City = new City(1, 'בני ברק', this.country);
  street: Street = new Street(1, 'רבי עקיבא', this.city)
  address: Address = new Address(1, this.country, this.city, 'רמת אלחנן', this.street, 5, 6, '51544');
  instetution: Institution = new Institution(1, 'כולל');
  attends: AttendanceRules = new AttendanceRules(1, 7, 10, 10);
  exam: ExamRules = new ExamRules(1, 7, true, 5, 'חורף');
  date: Date = new Date(1, 5, 2018);
  Scolarship1: Scolarship = new Scolarship(1, 12);
  branch: Branch = new Branch(1, this.branchType, this.exam, this.attends, this.Scolarship1, this.headUser, this.address, 'בני ברק', this.date, 40, 'הלכה', this.instetution, 'img111', true);
  branch1: Branch = new Branch(1, this.branchType, this.exam, this.attends, this.Scolarship1, this.headUser, this.address, 'בני ברק', this.date, 40, 'הלכה', this.instetution, 'img111', true);
  str: string;

  constructor(private branchService: BranchService,
    private translate: TranslateService,
    private router: Router) {
    this.translate.get('BRANCHES').subscribe(
      translation => {
        this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
        this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
        this.initColumnnDefs();
      });
  }

  ngOnInit() {
    environment.currentPage='branches';
    
    this.branchService.getBranches(1).subscribe((branches: Branch[]) => {
      this.branches = branches;
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  ngOnDestroy() {
    environment.currentPage='';
  }

  makeBranch1Active() {
    this.branchService.makeBranchActive(1).subscribe(() => {

    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  makeBranch1Inactive() {
    this.branchService.makeBranchInactive(1).subscribe(() => {

    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  InsertBranch() {
    this.branchService.InsertBranch(this.branch1).subscribe(() => {

    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  UpdateBranch() {
    this.branchService.UpdateBranch(this.branch).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  ReduceNumberOfStudents() {
    this.branchService.ReduceNumberOfStudents(1).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  IncreaseNumberOfStudents() {
    this.branchService.IncreaseNumberOfStudents(1).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  Contain() {
    this.branchService.Contain(this.str).subscribe((branches: Branch[]) => {
      this.branches = branches;
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  displayCounter(count) {
    alert(count);
  }

  selected(data: Branch[]) {
    environment.selected=data;
  }

  initColumnnDefs() {

    //TODO in english all the sentence changed?

    //address
    //TODO in english all the sentence changed?
    let street = this.columnWordsDefs["STREET"];
    let apartment = this.columnWordsDefs["APARTMENT"];

    //active/not active
    //TODO enum: Active/Inactive פעיל / לא פעיל
    let active = this.columnWordsDefs["ACTIVE"];
    let notActive = this.columnWordsDefs["NOT_ACTIVE"];

    //status
    let day = this.columnWordsDefs["DAY"];
    let evening = this.columnWordsDefs["EVENING"];

    let required = this.columnWordsDefs["REQUIRED"];
    let notRequired = this.columnWordsDefs["NOT_REQUIRED"];
    let maximumAbsences = this.columnWordsDefs["MAX_ABSENCES"];
    let maximumLateness = this.columnWordsDefs["MAX_LATENESS"];
    let examsPerPeriod = this.columnWordsDefs["EXAMS_PER_PERIOD"];;
    let examsPeriod = this.columnWordsDefs["EXAMS_PERIOD"];;

    img: String;
    this.columnDefs = [
      {

        headerName: this.columnHeaders["IMAGE"],
        headerTooltip: this.columnHeaders["IMAGE"],
        // field: 'image',
        //  cellTemplate:"<img width=\"50px\" ng-src=\"{{branch.Image}}\" lazy-src>"
        //  //cellTemplate:"<img width=\"50px\" ng-src=\"{{grid.getCellValue(row, col)}}\" lazy-src>"
        field: "Image",
        //cellTemplate:"<img width=\"199px\" ng-src=\"C:\IMG_2518.JPG\" >"
        //cellTemplate:"<img width=\"50px\" ng-src=\"{{grid.getCellValue(row, col)}}\" lazy-src>"
      },
      //{//תמונה
      //headerName: this.columnHeaders["IMAGE"],
      //headerTooltip: this.columnHeaders["IMAGE"],
      // cellRenderer: (params) => {
      //   let img= document.createElement('img');
      //   img.src=params.data.Image;
      //   return img;
      // },
      // tooltip: (params) => {
      //   let img= document.createElement('img');
      //   img.src=params.data.Image;
      //   return img;
      // },
      // minWidth: this.columnHeaders["IMAGE"].length * this.wWidth,
      // autoHeight: true,
      //},
      {//שם כולל
        headerName: this.columnHeaders["NAME"],
        headerTooltip: this.columnHeaders["NAME"],
        field: "Name",
        cellRenderer: (params) => {
          var a = document.createElement('a');
          a.innerText = params.value;
          a.style.textDecoration = 'underline';
          a.addEventListener('click', (e) => {
            e.preventDefault();
            this.router.navigate(['/branches/update',params.data.Id]);
          });
          return a;
        },
        tooltipField: 'Name',
        minWidth: this.columnHeaders["NAME"].length * this.wWidth,
        autoHeight: true,
      },
      {//עיר
        headerName: this.columnHeaders["CITY"],
        headerTooltip: this.columnHeaders["CITY"],
        valueGetter: (params) => { return (params.data.Address as Address).City.Name },
        tooltip: (params) => { return (params.data.Address as Address).City.Name },
        minWidth: this.columnHeaders["CITY"].length * this.wWidth + 10,
        autoHeight: true,
      },
      {//שכונה
        headerName: this.columnHeaders["NEIGHBORHOOD"],
        headerTooltip: this.columnHeaders["NEIGHBORHOOD"],
        valueGetter: (params) => { return (params.data.Address as Address).NeighborhoodName },
        tooltip: (params) => { return (params.data.Address as Address).NeighborhoodName },
        minWidth: this.columnHeaders["NEIGHBORHOOD"].length * this.wWidth,
        autoHeight: true,
      },
      {//כתובת        
        headerName: this.columnHeaders["ADRESS"],
        headerTooltip: this.columnHeaders["ADRESS"],
        cellRenderer: (params) => {
          return street + " " +
            (params.data.Address as Address).Street.Name + " " +
            (params.data.Address as Address).HouseNumber + " " +
            apartment + " " + (params.data.Address as Address).ApartmentNumber;
        },
        tooltip: (params) => {
          return street + " " +
            (params.data.Address as Address).Street.Name + " " +
            (params.data.Address as Address).HouseNumber + " " +
            apartment + " " + (params.data.Address as Address).ApartmentNumber;
        },
        minWidth: 150,
        autoHeight: true,
      },
      {//אופי
        headerName: this.columnHeaders["CHARACTER"],
        headerTooltip: this.columnHeaders["CHARACTER"],
        // cellRenderer: "TODO",
        // tooltip: "TODO",
        minWidth: this.columnHeaders["CHARACTER"].length * this.wWidth,
        autoHeight: true,
      },
      {//ראש כולל
        headerName: this.columnHeaders["HEAD"],
        headerTooltip: this.columnHeaders["HEAD"],
        valueGetter: (params) => {
          let s: string = "";
          if ((params.data.Head as UserExtraDetails).FirstName != null)
            s += (params.data.Head as UserExtraDetails).FirstName + " ";
          if ((params.data.Head as UserExtraDetails).LastName != null)
            s += (params.data.Head as UserExtraDetails).LastName
          return s;
        },
        tooltip: (params) => {
          let s: string = "";
          if ((params.data.Head as UserExtraDetails).FirstName != null)
            s += (params.data.Head as UserExtraDetails).FirstName + " ";
          if ((params.data.Head as UserExtraDetails).LastName != null)
            s += (params.data.Head as UserExtraDetails).LastName
          return s;
        },

        minWidth: this.columnHeaders["HEAD"].length * this.wWidth,
        autoHeight: true,
      },
      {//איש קשר
        headerName: this.columnHeaders["CONTACT"],
        headerTooltip: this.columnHeaders["CONTACT"],
        // // valueGetter: (params) => { 
        // //   let s="";
        // //   if((params.data as UserExtraDetails).FirstName!=null)
        // //   s+=(params.data as UserExtraDetails).FirstName+" ";
        // //   if((params.data.Head as UserExtraDetails).LastName!=null)
        // //   s+=(params.data.Head as UserExtraDetails).LastName;
        // //   return s;
        // // },
        // // tooltip: (params) => { 
        // //   return (params.data.Head as UserExtraDetails).FirstName+" "+ 
        // //   (params.data.Head as UserExtraDetails).LastName
        // // }, 
        minWidth: this.columnHeaders["CONTACT"].length * this.wWidth,
        autoHeight: true,
      },


      {//מלגת בסיס
        headerName: this.columnHeaders["BASIC_SUPPORT"],
        headerTooltip: this.columnHeaders["BASIC_SUPPORT"],
        // valueGetter: (params) => { 
        //   return (params.data.Scolarship as Scolarship).Amount; 
        // },
        // tooltip: (params) => {        
        //   return (params.data.Scolarship as Scolarship).Amount; 
        // }, 
        minWidth: this.columnHeaders["BASIC_SUPPORT"].length * this.wWidth,
        minHeight: 1200000000000,
        autoHeight: true,
      },
      {//מספר אברכים
        headerName: this.columnHeaders["STUDENTS"],
        headerTooltip: this.columnHeaders["STUDENTS"],
        field: 'StudentsNumber',
        cellRenderer: (params) => {
          var a = document.createElement('a');
          a.innerText = params.value;
          a.style.textDecoration = 'underline';
          a.addEventListener('click', (e) => {
            e.preventDefault();
            this.router.navigate(['/students/branchStudents', params.data.Id]);
          });
          return a;
        },
        tooltipField: 'StudentsNumber',
        minWidth: this.columnHeaders["STUDENTS"].length * this.wWidth,
        autoHeight: true,
      },
      {//סטטוס
        headerName: this.columnHeaders["STATUS"],
        headerTooltip: this.columnHeaders["STATUS"],
        cellRenderer: (params) => { return params.data.IsActive == true ? active : notActive },
        tooltip: (params) => { return params.data.IsActive == true ? active : notActive },
        minWidth: this.columnHeaders["STATUS"].length * this.wWidth,
        autoHeight: true,
      },
      {//סוג
        headerName: this.columnHeaders["TYPE"],
        headerTooltip: this.columnHeaders["TYPE"],
        // valueGetter: (params) => { return (params.data.Type as BranchType).Type },
        // tooltip: (params) => { return (params.data.Type as BranchType).Type },
        minWidth: this.columnHeaders["TYPE"].length * this.wWidth,
        autoHeight: true,
        hide: true,
      },
      {//כללי בחינות
        headerName: this.columnHeaders["EXAM_RULES"],
        headerTooltip: this.columnHeaders["EXAM_RULES"],
        // cellRenderer: function (params) {
        //   let s: string = "";
        //   if ((params.data.ExamRules as ExamRules).ExamsPerPeriod != 0)
        //     s = examsPerPeriod + ": " + (params.data.ExamRules as ExamRules).ExamsPerPeriod + '</br>';
        //   if ((params.data.ExamRules as ExamRules).ExamsPeriod != null)
        //     s += examsPeriod + ": " + (params.data.ExamRules as ExamRules).ExamsPeriod + '</br>';
        //   if ((params.data.ExamRules as ExamRules).IsRequiredExam == true)
        //     s += required;
        //   else
        //     s += notRequired;
        //   return s;
        // },
        // tooltip: function (params) {
        //   let s: string = "";
        //   if ((params.data.ExamRules as ExamRules).ExamsPerPeriod != 0)
        //     s = examsPerPeriod + ": " + (params.data.ExamRules as ExamRules).ExamsPerPeriod + " ";
        //   if ((params.data.ExamRules as ExamRules).ExamsPeriod != null)
        //     s += examsPeriod + ": " + (params.data.ExamRules as ExamRules).ExamsPeriod + " ";
        //   if ((params.data.ExamRules as ExamRules).IsRequiredExam == true)
        //     s += required;
        //   else
        //     s += notRequired;
        //   return s;
        // },
        minWidth: this.columnHeaders["EXAM_RULES"].length * this.wWidth,
        autoHeight: true,
        hide: true,
      },
      {//כללי נוכחות
        headerName: this.columnHeaders["ATTENDANCE_RULES"],
        headerTooltip: this.columnHeaders["ATTENDANCE_RULES"],
        // cellRenderer: function (params) {
        //   let s: string = "";
        //   if ((params.data.AttendanceRules as AttendanceRules).MaximumAbsences != undefined)
        //     s = maximumAbsences + ": " + (params.data.AttendanceRules as AttendanceRules).MaximumAbsences + '</br>';
        //   if ((params.data.AttendanceRules as AttendanceRules).MaximumLateness != undefined)
        //     s += maximumLateness + ": " + (params.data.AttendanceRules as AttendanceRules).MaximumLateness + ' </br>';

        //   return s;
        // },
        // tooltip: function (params) {
        //   let s: string = "";
        //   if ((params.data.AttendanceRules as AttendanceRules).MaximumAbsences != undefined)
        //     s = maximumAbsences + ": " + (params.data.AttendanceRules as AttendanceRules).MaximumAbsences + " ";
        //   if ((params.data.AttendanceRules as AttendanceRules).MaximumLateness != undefined)
        //     s += maximumLateness + ": " + (params.data.AttendanceRules as AttendanceRules).MaximumLateness + " ";
        //   return s;
        // },
        minWidth: this.columnHeaders["ATTENDANCE_RULES"].length * this.wWidth,
        autoHeight: true,
        hide: true,
      },
      {//תאריך פתיחה
        headerName: this.columnHeaders["OPENING_DATE"],
        headerTooltip: this.columnHeaders["OPENING_DATE"],
        tooltip: (params) => {
          return params.data.OpeningDate != null ? moment(params.data.OpeningDate).format('DD/MM/YYYY') : '';
        },
        valueGetter: (params) => {
          return params.data.OpeningDate;
        },
        valueFormatter: (params) => {
          return params.data.OpeningDate != null ? moment(params.data.OpeningDate).format('DD/MM/YYYY') : '';
        },
        cellClass: 'number-field',
        minWidth: this.columnHeaders["OPENING_DATE"].length * this.wWidth,
        autoHeight: true,
      },
      {//נושאים נלמדים
        headerName: this.columnHeaders["STUDY_SUBJECTS"],
        headerTooltip: this.columnHeaders["STUDY_SUBJECTS"],
        cellRenderer: (params) => { return params.data.StudySubjects; },
        tooltip: (params) => { return params.data.StudySubjects; },
        minWidth: this.columnHeaders["STUDY_SUBJECTS"].length * this.wWidth,
        hide: true,
        autoHeight: true,
        cellClass: 'cell-wrap-text',
      },

    ];

  }



}
