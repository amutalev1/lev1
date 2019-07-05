using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seldat.Amuta.Dal.DbContent;
namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlBranchActivityHoursDataManager : IBranchActivityHoursDataManager
    {
        private CommonDbContext _dbContext = null;
        public MySqlBranchActivityHoursDataManager()
        {
            _dbContext = new CommonDbContext();
        }
        public List<BranchActivityHours> GetBranchActivityHours(int branchId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@branch_id", branchId)
            };
            string sql = $"SELECT {Tables.BranchActivityHours.TableName}.*" +
               $" FROM {Tables.BranchActivityHours.TableName}" +
               $" WHERE {Tables.BranchActivityHours.BranchId.Name}=@branch_id";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            return BranchActivityHoursConverter.TableToBranchActivityHours(table);
        }

        public int InsertBranchActivityHours(BranchActivityHours branchActivityHours)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@branch_id",branchActivityHours.Branch.Id),
                new MySqlParameter("@late_hour", branchActivityHours.LateHour),
                new MySqlParameter("@start_study_hours", branchActivityHours.StartStudyHours),
                new MySqlParameter("@end_study_hours", branchActivityHours.EndStudyHours)
            };
            return _dbContext.Insert(Tables.BranchActivityHours.InsertTable, true, parameters);
        }
        public int UpdateBranchActivityHours(BranchActivityHours branchActivityHours)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", branchActivityHours.Id),
                new MySqlParameter("@late_hour", branchActivityHours.LateHour),
                new MySqlParameter("@start_study_hours", branchActivityHours.StartStudyHours),
                new MySqlParameter("@end_study_hours", branchActivityHours.EndStudyHours),
                new MySqlParameter("@branch_id", branchActivityHours.Branch.Id)
            };
            return _dbContext.Update(Tables.BranchActivityHours.UpdateTable, parameters);
        }
    }
}