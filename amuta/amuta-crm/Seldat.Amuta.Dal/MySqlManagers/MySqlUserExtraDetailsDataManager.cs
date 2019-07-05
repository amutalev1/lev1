using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using Seldat.Utils;
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
    public class MySqlUserExtraDetailsDataManager : IUserExtraDetailsDataManager
    {
        private  CommonDbContext _dbContext = new CommonDbContext();
        private static readonly IBaseLogger _logger;
        static MySqlUserExtraDetailsDataManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        public UserExtraDetails GetUserDetails(string Id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", Id),
            };
            string sql = $"SELECT * FROM {Tables.UserExtraDetails.TableName} WHERE {Tables.UserExtraDetails.UserId.Name}=@id";

            DataRow row = _dbContext.GetDataRow(sql, parameters);
            if (row == null)
                return null;
            return UserExtraDetailsConverter.RowToUserExtraDetails(row);
        }
        public int UpdateUserExtraDetails(UserExtraDetails userExtraDetails)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@user_id",userExtraDetails.UserId),
                new MySqlParameter("@identity_number", userExtraDetails.Identitynumber),
                new MySqlParameter("@phone_number", userExtraDetails.PhoneNumber),
                new MySqlParameter("@cellphone_number", userExtraDetails.CellphoneNumber),
                new MySqlParameter("@image", userExtraDetails.Image),
                new MySqlParameter("@address_id", userExtraDetails.Address.Id),
                new MySqlParameter("@first_name", userExtraDetails.FirstName),
                new MySqlParameter("@last_name", userExtraDetails.LastName),
                new MySqlParameter("@email", userExtraDetails.Email)
            };     
            return _dbContext.Update(Tables.UserExtraDetails.UpdateTable, parameters);
        }

        public int InsertUserExtraDetails(UserExtraDetails userExtraDetails)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@user_id",userExtraDetails.UserId),
               new MySqlParameter("@identity_number", userExtraDetails.Identitynumber),
               new MySqlParameter("@phone_number", userExtraDetails.PhoneNumber),
               new MySqlParameter("@cellphone_number", userExtraDetails.CellphoneNumber),
               new MySqlParameter("@image", userExtraDetails.Image),
               new MySqlParameter("@address_id", userExtraDetails.Address.Id),
               new MySqlParameter("@first_name", userExtraDetails.FirstName),
               new MySqlParameter("@last_name", userExtraDetails.LastName),
               new MySqlParameter("@email", userExtraDetails.Email)
           };
            return _dbContext.Insert(Tables.UserExtraDetails.InsertTable,true,parameters);
        }

        public int DeleteUserExtraDetails(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
