using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class CountryConverter
    {
        public static Country RowToCountry(DataRow row)
        {
            return new Country()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Countries.Id.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.Countries.Name.FullName)
            };
        }

        public static List<Country> TableToCountries(DataTable table)
        {
            List<Country> countries = new List<Country>();
            Country country = new Country();
            foreach (DataRow row in table.Rows)
            {
                country = RowToCountry(row);
                countries.Add(country);
            }
            return countries;
        }
    }
}