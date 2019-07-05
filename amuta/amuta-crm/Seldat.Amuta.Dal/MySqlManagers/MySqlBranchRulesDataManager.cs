using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using Seldat.Utils;
using Seldat.AspNet.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.MySqlManagers
{
   public class MySqlBranchRulesDataManager:IBranchRulesDataManager
    {
        private  CommonDbContext _dbContext = new CommonDbContext();
        public int InsertExamRules(ExamRules examRules)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {    
               new MySqlParameter("@branch_id",examRules.Branch.Id),
               new MySqlParameter("@is_required_exams",examRules.IsRequiredExams),
               new MySqlParameter("@exams_per_period",examRules.ExamsPerPeriod),
               new MySqlParameter("@exams_period",examRules.ExamsPeriod),
           };
            return _dbContext.Insert(Tables.ExamsRules.InsertTable, true, parameters);
        }
        public int InsertAttendanceRules(AttendanceRules attendanceRules)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@id",attendanceRules.Id),
               new MySqlParameter("@branch_id",attendanceRules.Branch.Id),
               new MySqlParameter("@maximum_lateness",attendanceRules.MaximumLateness),
               new MySqlParameter("@maximum_absences",attendanceRules.MaximumAbsences),            
           };
            return _dbContext.Insert(Tables.AttendanceRules.InsertTable, true, parameters);
        }
        public int UpdateExamRules(ExamRules examRules)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@id",examRules.Id),
               new MySqlParameter("@branch_id",examRules.Branch.Id),
               new MySqlParameter("@is_required_exams",examRules.IsRequiredExams),
               new MySqlParameter("@exams_per_period",examRules.ExamsPerPeriod),
               new MySqlParameter("@exams_period",examRules.ExamsPeriod),
           };

            return _dbContext.Update(Tables.ExamsRules.UpdateTable, parameters);
        }
        public int UpdateAttendanceRules(AttendanceRules attendanceRules)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@id",attendanceRules.Id),
               new MySqlParameter("@branch_id",attendanceRules.Branch.Id),
               new MySqlParameter("@maximum_lateness",attendanceRules.MaximumLateness),
               new MySqlParameter("@maximum_absences",attendanceRules.MaximumAbsences),
           };       
            return _dbContext.Update(Tables.AttendanceRules.UpdateTable, parameters);
        }
    }
}
