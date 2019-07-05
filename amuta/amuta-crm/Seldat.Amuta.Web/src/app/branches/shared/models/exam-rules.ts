export class ExamRules {
    constructor(
       public Id:number=0,
       public BranchId:number=0,
       public IsRequiredExam:boolean=true,
       public ExamsPerPeriod:number=0,
       public ExamsPeriod:string=''
    ){}
}
