using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class CityConverter
    {
        public static City RowToCity(DataRow row)
        {
            return new City()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Cities.Id.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.Cities.Name.FullName),
                Country=new Country (){ Id= DataRowHelper.GetValue<int>(row, Tables.Cities.CountryId.FullName) }
            };
        }

        public static List<City> TableToCities(DataTable table)
        {
            List<City> cities = new List<City>();
            City city = new City();
            foreach (DataRow row in table.Rows)
            {
                city = RowToCity(row);
                cities.Add(city);
            }
            return cities;
        }
    }
}