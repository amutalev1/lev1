import { Student } from './student.model';
import { Branch } from 'src/app/branches/shared/models/branch.model';
import { StudyPath } from 'src/app/branches/shared/models/study-path';

export class BranchStudent {
    constructor(
        //public Id:number=0,       
        public Student: Student=null ,
        public Branch :Branch=null,
        public EntryHebrewDate:Date=null ,
        public EntryGregorianDate:Date=null ,
        public ReleaseHebrewDate:Date=null,
        public ReleaseGregorianDate:Date=null ,
        public StudyPath :StudyPath=null ,
        public Status:number=0,
        public IsActive:boolean=false,
        public IsHead:boolean=false
    ){}

}
