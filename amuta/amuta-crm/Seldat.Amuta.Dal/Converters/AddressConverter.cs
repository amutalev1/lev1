using System.Data;
using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class AddressConverter
    {
        public static Address RowToAddress(DataRow row)
        {
            return new Address()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Address.Id.FullName),
                Country =CountryConverter.RowToCountry(row),
                City = CityConverter.RowToCity(row),
                NeighborhoodName = DataRowHelper.GetValue<string>(row, Tables.Address.NeighborhoodName.FullName),
                Street = StreetConverter.RowToStreet(row),
                HouseNumber = DataRowHelper.GetValue<int>(row, Tables.Address.HouseNumber.FullName),
                ApartmentNumber = DataRowHelper.GetValue<int?>(row, Tables.Address.ApartmentNumber.FullName),
                ZipCode = DataRowHelper.GetValue<string>(row, Tables.Address.ZipCode.FullName)
            };
        }
    }
}
