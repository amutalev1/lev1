import { Address } from 'src/app/shared/models/address.model';
import { BranchType } from './branch-type';
import { UserExtraDetails } from 'src/app/shared/models/user-extra-details';
import { ExamRules } from './exam-rules';
import { AttendanceRules } from './attendance-rules';
import { Institution } from 'src/app/shared/models/institution';
import { Scolarship } from './scolarship';


export class Branch {
    constructor(

        public  Id :number=0,
       
         public Type:BranchType=null ,
        
         public ExamRules: ExamRules=null,
       
         public AttendanceRules: AttendanceRules=null ,

         public Scolarship:Scolarship=null,
         
         public Head:UserExtraDetails=null  ,
        
         public Address: Address=null ,
      
         public Name:string=''  ,
       
         public OpeningDate:Date=null  ,

         public StudentsNumber:number=0 ,
   
         public StudySubjects:string='' ,
         
         public Institution :Institution=null,
       
        public Image:string=''  ,
        
        public IsActive:boolean=false ,

 

   
    ) {}
}
