export class AttendanceRules {
    constructor(
       public Id:number=0,
       public BranchId:number=0,    
       public MaximumLateness:number=0,
       public MaximumAbsences:number=0             
    ){}
}
