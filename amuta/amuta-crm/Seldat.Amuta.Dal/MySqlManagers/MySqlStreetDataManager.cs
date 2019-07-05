using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlStreetDataManager : IStreetDataManager
    {
        private CommonDbContext _dbContext = null;
        public MySqlStreetDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        public Street GetStreet(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };

            DataRow row = _dbContext.GetDataRow(Tables.Streets.Select, parameters);
            return StreetConverter.RowToStreet(row);
        }

        public List<Street> GetStreetsByCity(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id),
            };
            string sql = $"SELECT {Tables.Streets.TableName}.*" +
                $" FROM {Tables.Streets.TableName}" +
                $" WHERE {Tables.Streets.CityId.Name}=@id";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StreetConverter.TableToStreets(table);
            return new List<Street>();
        }

        public int InsertStreet(Street street)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", street.Id),
                new MySqlParameter("@name", street.Name),
                new MySqlParameter("@city_id", street.City.Id)
            };
            return _dbContext.Insert(Tables.Streets.InsertTable, true, parameters);
        }
    }
}
