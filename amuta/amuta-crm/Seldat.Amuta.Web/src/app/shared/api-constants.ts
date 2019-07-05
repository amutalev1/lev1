import { environment } from "../../environments/environment";

export class ApiConstants {
    public static apiEndpoint: string = environment.url;
   // =====================הקונטרולר של התלמידים
    public static studentEndpoint = ApiConstants.apiEndpoint + "api/student/";
    public static getStudents=ApiConstants.studentEndpoint+"getStudents";
    public static getStudent=ApiConstants.studentEndpoint+"getStudent"; 
    public static setStudentInactive=ApiConstants.studentEndpoint+"setStudentInactive";
    public static setStudentActive=ApiConstants.studentEndpoint+"setStudentActive";
    public static setStudentInactiveInBranch=ApiConstants.studentEndpoint+"setStudentInactiveInBranch";
    public static setStudentActiveInBranch=ApiConstants.studentEndpoint+"setStudentActiveInBranch";
    public static getStudentsOfBranch=ApiConstants.studentEndpoint+"getStudentsOfBranch"; 
    public static getStudentByIdentityNumber=ApiConstants.studentEndpoint+"getStudentByIdentityNumber";
    public static InsertPendingStudent=ApiConstants.studentEndpoint+"InsertPendingStudent"; 
    public static getPendingStudents=ApiConstants.studentEndpoint+"getPendingStudents";     
    public static approvalRegistration=ApiConstants.studentEndpoint+"approvalRegistration"; 
    public static InsertStudentPayment=ApiConstants.studentEndpoint+"InsertStudentPayment";    
    public static getPayment=ApiConstants.studentEndpoint+"getPayment"; 
    public static updateStudent=ApiConstants.studentEndpoint+"updateStudent";
    public static ContainsStudent=ApiConstants.studentEndpoint+"Contain";

 // =====================הקונטרולר של הסניפים
    public static branchEndpoint = ApiConstants.apiEndpoint +"api/branch/";
    public static GetBranches=ApiConstants.branchEndpoint+"GetBranches";
    public static GetBranch=ApiConstants.branchEndpoint+"GetBranch"; 
    public static MakeBranchActive=ApiConstants.branchEndpoint+"MakeBranchActive"; 
    public static MakeBranchInactive=ApiConstants.branchEndpoint+"MakeBranchInactive"; 
    public static InsertBranch=ApiConstants.branchEndpoint+"InsertBranch";
    public static UpdateBranch=ApiConstants.branchEndpoint+"UpdateBranch";
    public static GetBranchExamsBybranchId=ApiConstants.branchEndpoint+"GetBranchExamsBybranchId";
    public static ReduceNumberOfStudents=ApiConstants.branchEndpoint+"ReduceNumberOfStudents";
    public static IncreaseNumberOfStudents=ApiConstants.branchEndpoint+"IncreaseNumberOfStudents";
    public static GetBranchsActivityHoursByBranch=ApiConstants.branchEndpoint+"GetBranchsActivityHoursByBranch";
    public static GetExams=ApiConstants.branchEndpoint+"GetExams";
    public static ContainsBranch=ApiConstants.branchEndpoint+"Contain";
    public static Delete=ApiConstants.branchEndpoint+"Delete";

//=======================הקונטרולר של תמיכה כלכלית
    public static financialSupportEndpoint = ApiConstants.apiEndpoint +"api/financialSupport/";
    public static insertFinancialSupportRequest=ApiConstants.financialSupportEndpoint+"insertFinancialSupportRequest";
    public static GetFinancialSupportRequests=ApiConstants.financialSupportEndpoint+"GetFinancialSupportRequests";

//======================הקונטרולר של ההלוואות
   public static LoansEndPoint = ApiConstants.apiEndpoint +"api/loans/";
   public static InsertLoan=ApiConstants.LoansEndPoint+"InsertLoan";
   public static GetLoans=ApiConstants.LoansEndPoint+"GetLoans";
 
//======================הקונטרולר של כולליםותלמידים
   public static BranchStudentEndPoint = ApiConstants.apiEndpoint +"api/branchStudent/";
   public static RequestRegistrationBranchStudent=ApiConstants.BranchStudentEndPoint+"RequestRegistrationBranchStudent";
 
//======================הקונטרולר של תשלומים
   public static PaymentEndPoint = ApiConstants.apiEndpoint +"api/payment/";
   public static GetPayments=ApiConstants.PaymentEndPoint+"GetPayments";

}                 