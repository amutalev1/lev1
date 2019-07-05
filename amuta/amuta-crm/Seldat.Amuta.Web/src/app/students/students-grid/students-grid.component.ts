import { Component, OnInit, Input } from '@angular/core';
import *  as moment from 'moment';
import { Student } from '../shared/models/student.model';
import { TranslateService } from '@ngx-translate/core';
import { StudentService } from '../shared/services/student.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Address } from '../../shared/models/address.model';
import { Bank } from 'src/app/shared/models/bank.model';
import { StudentChild } from '../shared/models/student-child.model';
import { Branch } from 'src/app/branches/shared/models/branch.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from 'src/app/shared/models/country.model';
import { City } from 'src/app/shared/models/city.model';
import { Street } from 'src/app/shared/models/street.model';
import { BranchType } from 'src/app/branches/shared/models/branch-type';
import { ExamRules } from 'src/app/branches/shared/models/exam-rules';
import { AttendanceRules } from 'src/app/branches/shared/models/attendance-rules';
import { UserExtraDetails } from 'src/app/shared/models/user-extra-details';
import { Institution } from 'src/app/shared/models/institution';
import { Scolarship } from 'src/app/branches/shared/models/scolarship';
import { StudyPath } from 'src/app/branches/shared/models/study-path';
import { BranchStudent } from '../shared/models/branch-student';
import { BranchService } from 'src/app/branches/shared/services/branch.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-students-grid',
  templateUrl: './students-grid.component.html',
  styleUrls: ['./students-grid.component.scss']
})
export class StudentsGridComponent implements OnInit {

  students: Student[];
  columnHeaders: any[];
  columnDefs: any[];
  wWidth: number = 14;
  columnWordsDefs: any[];
  branchId: number;
  student: Student;
  branchShow: boolean;
  branchToShow: Branch;

  date: Date = new Date(1, 5, 2018);
  branchType: BranchType = new BranchType(1, 'הלכה', 'בוקר');
  country: Country = new Country(1, 'ישראל', 'י-ל', 123);
  city: City = new City(1, 'ערד', this.country);
  street: Street = new Street(1, 'רבי עקיבא', this.city)
  address: Address = new Address(1, this.country, this.city, 'רמת אהרון', this.street, 5, 6, '51544');
  bank: Bank = new Bank('457', 'זהב', '234')
  student1: Student = new Student(100, 'יחיאל', 'בר', '333333345', '123', this.address, this.date, 'img', '035797338', '0527174581', this.bank, '123456', 5, 5, 'אסתר', 'בר', 5000, 'shekel', 50, 'shekel', '035797338', true);
  kind: string;
  instetution: Institution = new Institution(1, 'כולל');
  headUser: UserExtraDetails = new UserExtraDetails('1', '207987793', '035797338', '0527174581', 'img', 1, 'אפרת', 'גנויאר', 'e7174581@gmail.com');
  attends: AttendanceRules = new AttendanceRules(1, 7, 10, 10);
  exam: ExamRules = new ExamRules(1, 7, true, 5, 'חורף');
  Scolarship: Scolarship = new Scolarship(1, 12.5);
  studyPath: StudyPath = new StudyPath(1, 'הלכה');
  branch: Branch = new Branch(1, this.branchType, this.exam, this.attends, this.Scolarship, this.headUser, this.address, 'בני ברק', this.date, 40, 'הלכה', this.instetution, 'img111', true);
  branchStud: BranchStudent = new BranchStudent(this.student1, this.branch, new Date(), new Date(), new Date(), new Date(), this.studyPath, 1, false);
  str: string;
  
  constructor(
    private studentService: StudentService,
    private translate: TranslateService,
    private route: ActivatedRoute,
    private branchService: BranchService,
    private router: Router) {
    this.route.data.subscribe(data => {
      this.kind = data.kind;
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
    this.translate.get('STUDENTS').subscribe(
      translation => {
        this.columnHeaders = translation["AG_GRID"]["COLUMN_HEADERS"];
        this.columnWordsDefs = translation["AG_GRID"]["COLUMN_WORDS_DEFS"];
      });
    this.initColumnnDefs();
    //currentPage = "students";
  }

  ngOnInit() {

    // this.studentService.getStudent(8).subscribe((student: Student) => {   
    //       this.student = student;
    //       alert((this.student as Student).IdentityNumber);
    //     },
    //       (error: HttpErrorResponse) => {
    //         alert(error.message)
    //       });
   environment.currentPage='students'
   
    this.route.params.subscribe(params => {
      this.branchId = +params['id']; // (+) converts string 'id' to a number
    });
    //how to use the same component in angular using routing each time for different thing
    this.route.data.subscribe(data => {
      
      this.kind = data.kind;
      switch (data.kind) {
        case 'allStudents': {//להחזרת כל התלמידים
          this.studentService.getStudents().subscribe((students: Student[]) => {
            this.students = students;
          },
            (error: HttpErrorResponse) => {
              alert(error.message)
            });
          break;
        }
        case 'pendingStudents': {//להחזרת תלמידים הממתינים לאישור
          this.studentService.getPendingStudents().subscribe((students: Student[]) => {
            this.students = students;

          },
            (error: HttpErrorResponse) => {
              alert(error.message)
            });
          break;
        }
        case 'branchStudents': {//להחזרת תלמידים לכולל מסוים
          this.studentService.getStudentsOfBranch(this.branchId).subscribe((students: Student[]) => {
            this.students = students;
            this.branchShow = true;
          },
            (error: HttpErrorResponse) => {
              alert(error.message)
            });
          this.branchService.getBranch(this.branchId).subscribe((branch: Branch) => {
            this.branchToShow = branch;
          },
            (error: HttpErrorResponse) => {
              alert(error.message)
            });
          break;
        }
        default: { //בררת מחדל מחזיר את כל התלמידים
          this.studentService.getStudents().subscribe((students: Student[]) => {
            this.students = students;
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

  ngOnDestroy() {
    environment.currentPage='';
  }
 
  setStudent1Active() {
    this.studentService.SetStudentActive(1, 1).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  setStudent1Inctive() {
    this.studentService.SetStudentInactive(1).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  setStudent1ActiveInBranch() {
    this.studentService.setStudentActiveInBranch(7, 1).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }
  setStudent1InactiveInBranch() {
    this.studentService.setStudentInactiveInBranch(7, 1).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  InsertPendingStudent() {
    this.studentService.InsertPendingStudent(this.student1, 28).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  approvalRegistration() {
    this.studentService.approvalRegistration(this.branchStud).subscribe(() => {
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  Contain() {
    this.studentService.Contain(this.str).subscribe((students: Student[]) => {
      this.students = students;
    },
      (error: HttpErrorResponse) => {
        alert(error.message)
      });
  }

  initColumnnDefs() {
    //address
    //TODO in english all the sentence changed?
    let street = this.columnWordsDefs["STREET"];
    let apartment = this.columnWordsDefs["APARTMENT"];
    //bank
    let bank = this.columnWordsDefs["BANK"];
    let branch = this.columnWordsDefs["BRANCH"];
    let account = this.columnWordsDefs["ACCOUNT"];
    //status
    //TODO enum: Active/Inactive/Applied/Pending , פעיל / לא פעיל / הוגשה בקשה / ממתין
    let active = this.columnWordsDefs["ACTIVE"];
    let notActive = this.columnWordsDefs["NOT_ACTIVE"];

    let approvalRegistration = this.columnWordsDefs["APPROVAL_REGISTRATION"];
    this.columnDefs = [
      {//מספר זהות
        headerName: this.columnHeaders["ID_NUMBER"],
        headerTooltip: this.columnHeaders["ID_NUMBER"],
        field: 'IdentityNumber',
        tooltipField: 'IdentityNumber',
        cellClass: ['number-field'],
        minWidth: this.columnHeaders["ID_NUMBER"].length * this.wWidth
      },
      {//שם פרטי
        headerName: this.columnHeaders["NAME"],
        headerTooltip: this.columnHeaders["NAME"],
        field: "FirstName",
        cellRenderer: (params) => {
          var a = document.createElement('a');
          a.innerText = params.value;
          a.style.textDecoration = 'underline';
          a.addEventListener('click', (e) => {
            e.preventDefault();
            this.router.navigate(['/students/update', params.data.Id]);
          });
          return a;
        },
        tooltipField: 'FirstName',
        minWidth: this.columnHeaders["NAME"].length * this.wWidth
      },
      {//שם משפחה
        headerName: this.columnHeaders["SURNAME"],
        headerTooltip: this.columnHeaders["SURNAME"],
        field: 'LastName',
        tooltipField: 'LastName',
        minWidth: this.columnHeaders["SURNAME"].length * this.wWidth
      },
      {//עיר
        headerName: this.columnHeaders["CITY"],
        headerTooltip: this.columnHeaders["CITY"],
        valueGetter: (params) => { return (params.data.Address as Address).City.Name },
        tooltipField: 'City',
        minWidth: this.columnHeaders["CITY"].length * this.wWidth + 10,
      },
      {//כתובת
        headerName: this.columnHeaders["ADDRESS"],
        headerTooltip: this.columnHeaders["ADDRESS"],
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
        maxWidth: 150
      },
      {//פרטי קשר
        headerName: this.columnHeaders["CONTACT_DETAILS"],
        headerTooltip: this.columnHeaders["CONTACT_DETAILS"],
        cellRenderer: (params) => {
          return params.data.PhoneNumber + '</br>' + params.data.CellphoneNumber;
        },
        tooltip: (params) => {
          return params.data.PhoneNumber + " " + params.data.CellphoneNumber;
        },
        autoHeight: true,
        cellClass: ['number-field', 'cell-wrap-text'],
        minWidth: this.columnHeaders["CONTACT_DETAILS"].length * this.wWidth,
      },
      {//סטטוס
        headerName: this.columnHeaders["STATUS"],
        headerTooltip: this.columnHeaders["STATUS"],
        cellRenderer: (params) => { return params.data.IsActive == true ? active : notActive },
        tooltip: (params) => { return params.data.IsActive == true ? active : notActive },
        minWidth: this.columnHeaders["STATUS"].length * this.wWidth
      },
      {//מספר ילדים
        headerName: this.columnHeaders["NUMBER_OF_CHILDREN"],
        headerTooltip: this.columnHeaders["NUMBER_OF_CHILDREN"],
        field: 'ChildrenNumber',
        tooltipField: 'ChildrenNumber',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["NUMBER_OF_CHILDREN"].length * this.wWidth
      },
      {//ילדים
        headerName: this.columnHeaders["CHILDREN"],
        headerTooltip: this.columnHeaders["CHILDREN"],
        valueFormatter: function (params) {
          let i = 0;
          let status;
          return params.data.StudentChildren[0].FirstName != null ? (params.data.StudentChildren as StudentChild[]).map(function (c) {
            status = c.Status.slice(0, 1);
            i++; if (i > 1) return "</br>" + c.FirstName + " " + c.Age + "&nbsp&nbsp&nbsp(" + status + ")";
            else return c.FirstName + " " + c.Age + "&nbsp&nbsp&nbsp(" + status + ")";
          }) : "";
        },
        tooltip: function (params) {
          return (params.data.StudentChildren as StudentChild[]).map(function (c) { c.Status != null ? status = c.Status.slice(0, 1) : status = null; return c.FirstName + " " + c.Age + "(" + status + ")" });
        },
        autoHeight: true,
        cellClass: ['cell-wrap-text'],
        hide: true,
        minWidth: this.columnHeaders["CHILDREN"].length * this.wWidth
      },
      {//ילדים נשואים
        headerName: this.columnHeaders["MARRIED_CHILDREN"],
        headerTooltip: this.columnHeaders["MARRIED_CHILDREN"],
        field: 'MarriedChildrenNumber',
        tooltipField: 'MarriedChildrenNumber',
        cellClass: 'number-field',
        minWidth: this.columnHeaders["MARRIED_CHILDREN"].length * this.wWidth
      },
      {//בת זוג
        headerName: this.columnHeaders["SPOUSE"],
        headerTooltip: this.columnHeaders["SPOUSE"],
        field: 'WifeName',
        tooltipField: 'WifeName',
        hide: true,
        minWidth: this.columnHeaders["SPOUSE"].length * this.wWidth
      },
      {//משלוח יד בת זוג
        headerName: this.columnHeaders["SPOUSE_OCCUPATION"],
        headerTooltip: this.columnHeaders["SPOUSE_OCCUPATION"],
        field: 'JobWife',
        tooltipField: 'JobWife',
        hide: true,
        minWidth: this.columnHeaders["SPOUSE_OCCUPATION"].length * this.wWidth
      },
      {//תאריך לידה
        headerName: this.columnHeaders["BIRTH_DATE"],
        headerTooltip: this.columnHeaders["BIRTH_DATE"],
        tooltip: (params) => {
          return params.data.BornDate != null ? moment(params.data.BornDate).format('DD/MM/YYYY') : '';
        },
        valueGetter: (params) => {
          return params.data.BornDate;
        },
        valueFormatter: (params) => {
          return params.data.BornDate != null ? moment(params.data.BornDate).format('DD/MM/YYYY') : '';
        },
        cellClass: 'number-field',
        minWidth: this.columnHeaders["BIRTH_DATE"].length * this.wWidth
      },
      {//מוסדות נוספים
        headerName: this.columnHeaders["OTHER_SCHOOLS"],
        headerTooltip: this.columnHeaders["OTHER_SCHOOLS"],
        field: 'TODO',
        tooltipField: 'TODO',
        minWidth: this.columnHeaders["OTHER_SCHOOLS"].length * this.wWidth
      },
      {//תמיכה
        headerName: this.columnHeaders["SUPPORT"],
        headerTooltip: this.columnHeaders["SUPPORT"],
        field: 'TODO',
        tooltipField: 'TODO',
        minWidth: this.columnHeaders["SUPPORT"].length * this.wWidth
      },
      {//חשבון בנק
        headerName: this.columnHeaders["BANK_ACCOUNT"],
        headerTooltip: this.columnHeaders["BANK_ACCOUNT"],
        cellRenderer: function (params) {
          return bank + " " + (params.data.Bank as Bank).Name + '</br>' +
            branch + " " + (params.data.Bank as Bank).BranchNumber + '</br>' +
            account + " " + params.data.AccountNumber;
        },
        tooltip: function (params) {
          return bank + " " + (params.data.Bank as Bank).Name + " " +
            branch + " " + (params.data.Bank as Bank).BranchNumber + " " +
            account + " " + params.data.AccountNumber;
        },
        hide: true,
        autoHeight: true,
        cellClass: ['cell-wrap-text'],
        minWidth: this.columnHeaders["BANK_ACCOUNT"].length * this.wWidth
      },
      {//מצב משפחתי
        headerName: this.columnHeaders["MARTIAL_STATUS"],
        headerTooltip: this.columnHeaders["MARTIAL_STATUS"],
        field: 'MartialStatus',
        tooltipField: 'MartialStatus',
        hide: true,
        minWidth: this.columnHeaders["MARTIAL_STATUS"].length * this.wWidth
      },
      {//הכנסה חודשית
        headerName: this.columnHeaders["MONTHLY_INCOME"],
        headerTooltip: this.columnHeaders["MONTHLY_INCOME"],
        field: 'MonthlyIncome',
        tooltipField: 'MonthlyIncome',
        hide: true,
        cellClass: 'number-field',
        minWidth: this.columnHeaders["MONTHLY_INCOME"].length * this.wWidth
      },
      {//הוצאות נסיעה
        headerName: this.columnHeaders["TRAVEL_EXPENSES"],
        headerTooltip: this.columnHeaders["TRAVEL_EXPENSES"],
        field: 'TravelExpenses',
        tooltipField: 'TravelExpenses',
        hide: true,
        cellClass: 'number-field',
        minWidth: this.columnHeaders["TRAVEL_EXPENSES"].length * this.wWidth
      },
      {//מספר פקס
        headerName: this.columnHeaders["FAX_NUMBER"],
        headerTooltip: this.columnHeaders["FAX_NUMBER"],
        field: 'FaxNumber',
        tooltipField: 'FaxNumber',
        hide: true,
        cellClass: 'number-field',
        minWidth: this.columnHeaders["FAX_NUMBER"].length * this.wWidth
      },
      {//תמונה
        headerName: this.columnHeaders["PICTURE"],
        headerTooltip: this.columnHeaders["PICTURE"],
        field: 'Image',
        tooltipField: 'Image',
        hide: true,
        minWidth: this.columnHeaders["PICTURE"].length * this.wWidth
      },
      {//תמונת ת.ז
        headerName: this.columnHeaders["ID_CARD"],
        headerTooltip: this.columnHeaders["ID_CARD"],
        field: 'IdCard',
        tooltipField: 'IdCard',
        hide: true,
        minWidth: this.columnHeaders["ID_CARD"].length * this.wWidth
      },
      {//אשר
        // id:approvalRegistration,
        // headerName: this.columnHeaders["APPROVAL_REGISTRATION"],
        // headerTooltip: this.columnHeaders["APPROVAL_REGISTRATION"],
        // cellRenderer: (data) => {
        //   var b=document.createElement('button');
        //   b.innerHTML=approvalRegistration;
        //   b.addEventListener('click', function () {      
        //     alert("approval this student");
        //     approvalRegistration();       
        //   });
        //   return b;
        // },
        // hide:this.kind!='pendingStudents',
        // minWidth: this.columnHeaders["APPROVAL_REGISTRATION"].length * this.wWidth
      }
    ];
  }
}
