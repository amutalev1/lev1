using System.Collections.Generic;

namespace Seldat.Amuta.Entities.Managers
{
   public interface IBankDataManager
    {
        int InsertBank(Bank bank);
        Bank GetBank(int id);
        List<Bank> GetBanks();
        int UpdateBank(Bank bank);
    }
}
