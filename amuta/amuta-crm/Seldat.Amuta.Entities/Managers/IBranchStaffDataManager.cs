using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities.Managers
{
   public interface IBranchStaffDataManager
    {
        List<BranchStaff> GetBranchStaffByBranchId(int id);
        int InsertBranchStaff(BranchStaff branchStaff);
        int DeleteBranchStaff(int id);

    }
}
