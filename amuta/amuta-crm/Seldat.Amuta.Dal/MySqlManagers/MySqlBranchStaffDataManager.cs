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
    class MySqlbranchStaffDataManager:IBranchStaffDataManager
    {
        private static CommonDbContext _dbContext = new CommonDbContext();
        public List<BranchStaff> GetBranchStaffByBranchId(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
               new MySqlParameter("@id",id)
            };

            string sql = $"SELECT * FROM {Tables.BranchStaff.TableName} WHERE {Tables.BranchStaff.BranchId.Name}=@id";
            DataTable table = _dbContext.GetDataTable(sql, null);
            if (table != null)
                return BranchStaffConverter.TableToBranchStaff(table);
            return new List<BranchStaff>();
        }
        public int InsertBranchStaff(BranchStaff branchStaff)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@branch_id",branchStaff.Branch.Id),
               new MySqlParameter("@user_id",branchStaff.User.UserId),
               new MySqlParameter("@role_id",branchStaff.Role.Id),
           };
            return _dbContext.Insert(Tables.BranchStaff.InsertTable, true, parameters);
        }
        public int DeleteBranchStaff(int id)
        {
            throw new NotImplementedException();
        }
    }
}
