import { Time } from '@angular/common';
import { Branch } from './branch.model';

export class ActivityHours {
    constructor(
      
        public  Id:number=0,
        
        public Branch: Branch=null,
      
        public LateHour:Time=null,
       
        public StartStudyHours:Time=null ,
        
        public EndStudyHours:Time=null ,
    ){}
}
