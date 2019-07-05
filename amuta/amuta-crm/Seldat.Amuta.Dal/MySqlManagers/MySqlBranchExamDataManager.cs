using System;
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
  public  class MySqlBranchExamDataManager : IBranchExamDataManager
    {
        private  CommonDbContext _dbContext = new CommonDbContext();
        public List<BranchExam> GetBranchExamsByBranchId(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
               new MySqlParameter("@id",id)
            };

            string sql = $"SELECT * FROM {Tables.BranchExams.TableName} WHERE {Tables.BranchExams.BranchId.Name}=@id";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchExamConverter.TableToBranchExam(table);
            return new List<BranchExam>();
        }
        public List<BranchExam> GetExams()
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {

            };

            string sql = $"SELECT * FROM {Tables.BranchExams.TableName}";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchExamConverter.TableToBranchExam(table);
            return new List<BranchExam>();
        }
        public int InsertBranchExam(BranchExam branchExam)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
             new MySqlParameter("@branch_id",branchExam.Branch.Id),
             new MySqlParameter("@failing_sumbit_exam_scholarship_addition",branchExam.SumbitExamScholarshipAddition),
             new MySqlParameter("@failing_sumbit_exam_scholarship_reducing",branchExam.FailingSumbitExamScholarshipReducing),
             new MySqlParameter("@not_passed_exam_scholarship_addition",branchExam.PassedExamScholarshipAddition),
             new MySqlParameter("@not_passed_exam_scholarship_reducing",branchExam.NotPassedExamScholarshipReducing),
             new MySqlParameter("@pass_grade",branchExam.PassGrade),
             new MySqlParameter("@subject",branchExam.Subject),          
           };
            return _dbContext.Insert(Tables.BranchExams.InsertTable, true, parameters);
        }
        public int UpdateBranchExam(BranchExam branchExam)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
             new MySqlParameter("@id",branchExam.Id),
             new MySqlParameter("@branch_id",branchExam.Branch.Id),
             new MySqlParameter("@failing_sumbit_exam_scholarship_addition",branchExam.SumbitExamScholarshipAddition),
             new MySqlParameter("@failing_sumbit_exam_scholarship_reducing",branchExam.FailingSumbitExamScholarshipReducing),
             new MySqlParameter("@not_passed_exam_scholarship_addition",branchExam.PassedExamScholarshipAddition),
             new MySqlParameter("@not_passed_exam_scholarship_reducing",branchExam.NotPassedExamScholarshipReducing),
             new MySqlParameter("@pass_grade",branchExam.PassGrade),
             new MySqlParameter("@subject",branchExam.Subject),
            };
            return _dbContext.Update(Tables.BranchExams.UpdateTable, parameters);
        }
        public int DeleteBranchExam(int id)
        {
            throw new NotImplementedException();
        }
    }
}
