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
    //to do-----------------
    public class MySqlScolarshipDataManager : IScolarshipDataManager
    {
        private static CommonDbContext _dbContext = new CommonDbContext();
        public Scolarship GetScolarship(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id),
            };
            DataRow row = _dbContext.GetDataRow(Tables.Scolarships.Select, parameters);
            if (row == null)
                return null;
            return ScolarshipConverter.RowToScolarship(row);
        }
        public int InsertScolarship(Scolarship scolarship)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@amount",scolarship.Amount),                
           };

            return _dbContext.Insert(Tables.Scolarships.InsertTable, true, parameters);
        }

        public int UpdateScolarship(Scolarship scolarship)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@id",scolarship.Id),
               new MySqlParameter("@amount",scolarship.Amount),
           };
            return _dbContext.Update(Tables.Scolarships.UpdateTable, parameters);
        }
    }
}
