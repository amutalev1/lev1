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
   public class MySqlCountryDataManager : ICountryDataManager
    {
        private CommonDbContext _dbContext = null;
        public MySqlCountryDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        public List<Country> GetCountries()
        {
            DataTable table = _dbContext.GetDataTable(Tables.Countries.SelectAllTable,null);
            if (table != null)
                return CountryConverter.TableToCountries(table);
            return new List<Country>(); 
        }

        public Country GetCountry(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };

            DataRow row = _dbContext.GetDataRow(Tables.Countries.Select, parameters);
            return CountryConverter.RowToCountry(row);
        }

        public int InsertCountry(Country country)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@name", country.Name)
            };
            return _dbContext.Insert(Tables.Countries.InsertTable,true, parameters);
        }
    }
}
