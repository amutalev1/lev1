
namespace Seldat.Amuta.Entities.Managers
{
    public interface ILoanDataManager
    {
        int InsertLoan(LoanSupportRequest loan);

        LoanSupportRequests GetAllLoans(int? from, int? amount);
    }
}
