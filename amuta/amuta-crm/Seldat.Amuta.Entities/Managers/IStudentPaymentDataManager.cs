
namespace Seldat.Amuta.Entities.Managers
{
    public interface IStudentPaymentDataManager
    {
        StudentPayments GetAllPayments(int? from, int? amount);
    }
}
