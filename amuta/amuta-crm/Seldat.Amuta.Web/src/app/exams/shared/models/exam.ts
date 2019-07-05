import { Branch } from 'src/app/branches/shared/models/branch.model';

export class Exam {

    constructor(
        public  Id :number,
        public  Branch :Branch ,
        public  SumbitExamScholarshipAddition:number,
        public  FailingSumbitExamScholarshipReducing :number,
        public  PassedExamScholarshipAddition :number,
        public  NotPassedExamScholarshipReducing :number,
        public  PassGrade:number ,
        public  Subject:string ,
    ){}
}
