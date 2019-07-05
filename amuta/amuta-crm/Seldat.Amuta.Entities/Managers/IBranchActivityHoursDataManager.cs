using System.Collections.Generic;

namespace Seldat.Amuta.Entities.Managers
{
    public interface IBranchActivityHoursDataManager
    {
       List<BranchActivityHours> GetBranchActivityHours(int branchId);
        int InsertBranchActivityHours(BranchActivityHours branchActivityHours);
        int UpdateBranchActivityHours(BranchActivityHours branchActivityHours);
    }
}