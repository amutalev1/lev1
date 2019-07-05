import { Student } from 'src/app/students/shared/models/student.model';

export class Payment {
    constructor(      
        public Id:number ,
        public Student:Student ,
        public Year:number ,
        public Month:number,
        public PaymentSum:number ,
        public AttendanceSum:number ,
        public ExamsSum:number ,
        public StateBudgetSum:number ,
        public HealthSupportSum:number ,
        public DentalHealthSupportSum:number ,
        public FinancialSupportSum:number ,
        public LoansGivenSum:number ,
        public LoansReturnSum:number 
    ){}
}
