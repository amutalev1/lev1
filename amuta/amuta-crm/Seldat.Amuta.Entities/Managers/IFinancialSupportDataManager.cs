using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities.Managers
{
    public interface IFinancialSupportDataManager
    {
        int InsertFinancialSupportRequest(FinancialSupportRequest financialSupportRequest);

        FinancialSupportRequests GetFinancialSupports();
    }
}
