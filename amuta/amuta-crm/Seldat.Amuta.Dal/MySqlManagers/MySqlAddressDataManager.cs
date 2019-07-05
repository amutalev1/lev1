using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using static Seldat.Amuta.Dal.DbContent;
using Seldat.Amuta.Entities.Managers;

namespace Seldat.Amuta.Dal.MySqlManagers
{
   public class MySqlAddressDataManager : IAddressDataManager
    {
        private CommonDbContext _dbContext = null;

        public MySqlAddressDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        public Address GetAddress(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };


            DataRow row = _dbContext.GetDataRow(Tables.Address.Select, parameters);
            return AddressConverter.RowToAddress(row);

        }

        public int InsertAddress(Address address)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@country_id", address.Country.Id),
                new MySqlParameter("@city_id", address.City.Id),
                new MySqlParameter("@neighborhood_name", address.NeighborhoodName!=null? address.NeighborhoodName:null),
                new MySqlParameter("@street_id", address.Street.Id),
                new MySqlParameter("@house_number", address.HouseNumber),
                new MySqlParameter("@apartment_number", address.ApartmentNumber!=null? address.ApartmentNumber:null),
                new MySqlParameter("@zip_code", address.ZipCode!=null? address.ZipCode:null)
            };
            return _dbContext.Insert(Tables.Address.InsertTable,true, parameters);
        }

        public int UpdateAddress(Address address)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", address.Id),
                new MySqlParameter("@country_id", address.Country.Id),
                new MySqlParameter("@city_id", address.City.Id),
                new MySqlParameter("@neighborhood_name", address.NeighborhoodName!=null? address.NeighborhoodName:null),
                new MySqlParameter("@street_id", address.Street.Id),
                new MySqlParameter("@house_number", address.HouseNumber),
                new MySqlParameter("@apartment_number", address.ApartmentNumber!=null? address.ApartmentNumber:null),
                new MySqlParameter("@zip_code", address.ZipCode!=null? address.ZipCode:null)
            };
            return _dbContext.Update(Tables.Address.UpdateTable, parameters);
        }

        //TODO: do we need it?
        public int DeleteAddress(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };
            return _dbContext.Delete(Tables.Address.Delete, parameters);

        }
    }
}
