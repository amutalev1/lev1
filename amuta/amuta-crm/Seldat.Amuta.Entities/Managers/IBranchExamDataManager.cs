using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities.Managers
{
  public interface IBranchExamDataManager
    {
        List<BranchExam> GetBranchExamsByBranchId(int id);
        List<BranchExam> GetExams();
        int InsertBranchExam(BranchExam BranchExam);
        int UpdateBranchExam(BranchExam BranchExam);
        int DeleteBranchExam(int id);
    }
}
