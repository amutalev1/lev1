import { Student } from 'src/app/students/shared/models/student.model';
import { Branch } from 'src/app/branches/shared/models/branch.model';
import { LoanGuarantor } from './loan-guarantor';

export class Loans {


constructor(
    public Id:number=0  ,
    public Student:Student=null ,
    public branch:Branch=null,
    public Date:Date=null,
    public Details:string='',
    public IsApproved:boolean=false,
    public CurrentStatus:number=0, 
    public Iscanceled:boolean=false,
    public AmountRequested:number=0,
    public AmountRepaymentMonthly:number=0 ,
    public DateReturningEntireAmount:Date=null ,
    public  ReasonIsApproved:string='',
    public  IsDisapprovedClosedRequest:boolean=true ,
    //public byte[] DigitalSignature ,
    public NumberApprovedMonths:number=0 ,
    public ApprovedAmount:number=0,
    public LoanGuarantors:LoanGuarantor[]=null
){}

}
