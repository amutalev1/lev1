import { Student } from './student.model';

export class StudentPayment {
    constructor(
       public Student:Student=null ,
       public Year:number=0 ,
       public Month:number=0 ,
       public PaymentSum:number=0 ,
       public AttendanceSum:number=0,
       public ExamsSum:number=0 ,
       public StateBudgetSum:number=0 ,
       public HealthSupportSum:number=0 ,
       public DentalHealthSupportSum:number=0 ,
       public FinancialSupportSum:number=0 ,
       public LoansGivenSum:number=0,
       public loansReturnSum:number=0
    ){}
   
}
