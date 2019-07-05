import { Student } from 'src/app/students/shared/models/student.model';
import { Branch } from 'src/app/branches/shared/models/branch.model';

export class FinancialSupport {
    constructor(
        public ApprovedAmount:number ,
        public NumberOfMonthsApprovedt:number,
        public Id:number,
        public Student: Student ,
        public branch:Branch ,
        public Date:Date ,
        public Details:string ,
        public IsApproved:boolean ,
        public CurrentStatus:number ,
        public Iscanceled:boolean ,
    ){}
}
