using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities.Managers
{
    public interface IBranchDataManager
    {
        Branches GetBranchesByType(int id,Branch.Includes includes);
        Branch GetBranchById(int id, Branch.Includes includes);
        int InsertBranch(Branch branch);
        int UpdateBranch(Branch branch);
        int MakeBranchInactive(int id);
        int MakeBranchActive(int id);
        int IncreaseNumberOfStudents(int branchId);
        int ReduceNumberOfStudents(int branchId);
        Branches Contains(Branch.Includes includes, string str);
        int Delete(Branch branch);
    }
}
