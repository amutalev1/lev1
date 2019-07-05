using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.MySqlManagers
{
   public class MySqlCityDataManager : ICityDataManager
    {
        private CommonDbContext _dbContext = null;
        public MySqlCityDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        public List<City> GetCitiesByCountry(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id),
            };
            string sql = $"SELECT {Tables.Cities.TableName}.*" +
                $" FROM {Tables.Cities.TableName}" +
                $" WHERE {Tables.Cities.CountryId.Name}=@id";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return CityConverter.TableToCities(table);
            return new List<City>();
        }

        public City GetCity(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };

            DataRow row = _dbContext.GetDataRow(Tables.Cities.Select, parameters);
            return CityConverter.RowToCity(row);
        }

        public int InsertCity(City city)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@name", city.Name),
                new MySqlParameter("@country_id", city.Country.Id)
            };
            return _dbContext.Insert(Tables.Cities.InsertTable,true, parameters);
        }
    }
}
