using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class StreetConverter
    {
        public static Street RowToStreet(DataRow row)
        {
            return new Street()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Streets.Id.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.Streets.Name.FullName),
                City = new City() { Id = DataRowHelper.GetValue<int>(row, Tables.Streets.CityId.FullName) }
            };
        }

        public static List<Street> TableToStreets(DataTable table)
        {
            List<Street> streets = new List<Street>();
            Street street = new Street();
            foreach (DataRow row in table.Rows)
            {
                street = RowToStreet(row);
                streets.Add(street);
            }
            return streets;
        }
    }
}