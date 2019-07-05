using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seldat.AspNet.Identity.DbContent.Tables;

namespace Seldat.AspNet.Identity.Managers.MySql
{
    internal class MySqlLoginManager<TUser> : ILoginManager<TUser> where TUser : User, new()
    {
        private CommonDbContext db = new CommonDbContext();

        public int AddLogin(TUser user, UserLoginInfo login)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
                new MySqlParameter("@LoginProvider", login.LoginProvider),
                new MySqlParameter("@ProviderKey", login.ProviderKey),
                new MySqlParameter("@UserId",user.Id)
        };
            string sqlStr = $"insert into {UserLogins.TableName} values(@LoginProvider, @ProviderKey, @UserId)";
            return db.Insert(sqlStr, true, parameters);
        }

        public TUser Find(UserLoginInfo login)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
                new MySqlParameter("@LoginProvider", login.LoginProvider),
                new MySqlParameter("@ProviderKey", login.ProviderKey)
        };
            string query = $"select {UserLogins.UserId.Name} from {UserLogins.TableName} where {UserLogins.LoginProvider.Name}=@LoginProvider and {UserLogins.ProviderKey.Name}=@ProviderKey ";
            DataRow row = db.GetDataRow(query, parameters);
            if (row != null)
            {
                string id = row[UserLogins.UserId.Name].ToString();

                parameters.Add(new MySqlParameter("@UserId", id));
                string sqlStr = $"select * from {Users.TableName} where {Users.Id.Name}=@UserId";
                DataRow rowUser = db.GetDataRow(sqlStr, null);
                return Converters.DataRowToUser<TUser>(rowUser);
            }
            return null;
        }

        public IList<UserLoginInfo> GetLogins(TUser user)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
                new MySqlParameter("@UserId",user.Id)
            };

            string query = $"select * from {UserLogins.TableName} where {UserLogins.UserId.Name}=@UserId";
            var dt = db.GetDataTable(query, parameters);

            IList<UserLoginInfo> logins = new List<UserLoginInfo>();
            foreach (DataRow row in dt.Rows)
            {
                UserLoginInfo userLoginInfo = new UserLoginInfo(row[UserLogins.LoginProvider.Name].ToString(), row[UserLogins.ProviderKey.Name].ToString());
                logins.Add(userLoginInfo);
            }
            return logins;
        }

        public int RemoveLogin(TUser user, UserLoginInfo login)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
                new MySqlParameter("@LoginProvider", login.LoginProvider),
                new MySqlParameter("@ProviderKey", login.ProviderKey),
                new MySqlParameter("@UserId",user.Id)
            };
            string query = $"delete from {UserLogins.TableName} where {UserLogins.LoginProvider.Name}=@LoginProvider and {UserLogins.ProviderKey.Name}=@ProviderKey and {UserLogins.UserId.Name}=@UserId";
            return db.Delete(query, parameters);
        }
    }
}
