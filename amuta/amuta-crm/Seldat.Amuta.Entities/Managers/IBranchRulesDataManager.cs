using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities.Managers
{
  public  interface IBranchRulesDataManager
    {
        int InsertExamRules(ExamRules examRules);
        int InsertAttendanceRules(AttendanceRules attendanceRules);
        int UpdateExamRules(ExamRules examRules);
        int UpdateAttendanceRules(AttendanceRules attendanceRules);
    }
}
