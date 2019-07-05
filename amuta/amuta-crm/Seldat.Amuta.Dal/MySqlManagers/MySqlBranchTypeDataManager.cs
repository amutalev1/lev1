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
   public class MySqlBranchTypeDataManager:IBranchTypeDataManager
    {
        private static CommonDbContext _dbContext = new CommonDbContext();
        public BranchType GetBranchType(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id),
            };
            DataRow row = _dbContext.GetDataRow(Tables.BranchTypes.Select, parameters);
            if (row == null)
                return null;
            return BranchTypeConverter.RowToBranchType(row);
        }
    }
}
