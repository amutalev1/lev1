
namespace Seldat.Amuta.Entities.Managers
{
    public interface IBranchStudentDataManager
    {
        BranchesStudents GetAllStudentsToBranch(int branchId);
        int SetStudentInactiveInBranch(int studentId, int branchId, string releaseHebrewDate);
        int SetStudentActiveInBranch(int branchStudentId);
        int ApprovalRegistrationStudent(int branchStudentId, string entryHebrewDate);
       // int RequestRegistrationBranchStudent(BranchStudent branchStudent);
        BranchesStudents GetBranchesOfStudent(int studentId);
        BranchesStudents GetBranchesOfPendingStudent(int id);
        BranchesStudents GetBranchesInactiveStudent(int id);
        BranchesStudents GetBranchesOfPendingStudents();
        int RequestRegistrationBranchStudent(BranchStudent branchStudent);
        int RequestRegistrationBranchStudent(int studentId, int branchId, int? studyPathId);
        int RegistrationStudentToBranch(int studentId, int branchId, string entryHebrewDate);
        BranchesStudents GetActiveBranchesOfStudent(int studentId,Student.Includes includes=Student.Includes.None);
        int MakeBranchStudentsInactive(int branchId);
    }
}
