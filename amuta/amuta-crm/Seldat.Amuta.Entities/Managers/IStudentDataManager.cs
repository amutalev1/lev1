
namespace Seldat.Amuta.Entities.Managers
{
    public interface IStudentDataManager
    {
        Students GetAllStudents(Student.Includes include, int? from, int? amount);
       // Students GetStudentsByBranchId(int id);
        Student GetStudent(int studentId, Student.Includes include);
        Student GetStudentByIdentityNumber(int studentIdentityNumber, Student.Includes include);
        Student GetPendingStudent(int studentId);
        Students GetPendingStudents(Student.Includes include);
        int UpdateStudent(Student student);
        int SetStudentInactive(int studentId);
        int SetStudentActive(int studentId);
        decimal GetPayment(int studentId);
        int InsertPendingStudent(Student student);
        bool IsExistIdentityNumber(string identityNumber, int studentId);
        Students GetStudentsOfBranch(int institutionId, Student.Includes includes,int? from,int? amount);
        int InsertStudentPayment(StudentPayment studentPayment);
        Students Contains(Student.Includes includes, string str);
    }
}
