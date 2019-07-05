using System;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using static Seldat.AspNet.Identity.DbContent.Tables;

namespace Seldat.AspNet.Identity.Managers.MySql
{
    internal class MySqlUserPassManager<TUser> : IUserPassManager<TUser> where TUser : User
    {
        CommonDbContext db = new CommonDbContext();
        public string GetPasswordHashAsync(TUser user)
        {
            List<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@userId",user.Id)
            };
            string query = $"SELECT {Users.PasswordHash.Name} from {Users.TableName} where {Users.Id.Name} = @userId";
            return db.GetDataRow(query, null)[Users.PasswordHash.Name].ToString();
        }

        public bool HasPasswordAsync(TUser user)
        {
            string query = $"SELECT {Users.PasswordHash.Name} FROM {Users.TableName} WHERE {Users.Id.Name} = @UserId";
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", user.Id)
            };
            string pass = db.GetDataRow(query, parameters)[Users.PasswordHash.Name].ToString();
            return (pass != null && pass != string.Empty);       
        }

        public int SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return 1;
        }

        public int SetPasswordValidity(TUser user, int expired)
        {
            DateTime passwordCreated = DateTime.UtcNow;
            DateTime passwordExpired = DateTime.UtcNow.AddDays(expired);
            IList<DbParameter> parameters = new List<DbParameter>()
           {
                new MySqlParameter("@UserId", (user as User).Id),
                new MySqlParameter("@PasswordCreated",passwordCreated),
                new MySqlParameter("@PasswordExpired",passwordExpired)
           };
            string query = $"UPDATE {Users.TableName} SET {Users.PasswordCreated.Name}=@PasswordCreated, {Users.PasswordExpired.Name}=@PasswordExpired WHERE {Users.Id.Name} = @UserId";
            return db.Update(query, parameters);
        }


        public int UpdateAsync(TUser user)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
                new MySqlParameter("@UserId", user.Id),
                new MySqlParameter("@PasswordHash", user.PasswordHash),
                new MySqlParameter("@SecurStemp", user.SecurityStamp),
                new MySqlParameter("@PasswordCreated",user.PasswordCreated),
                new MySqlParameter("@PasswordExpired",user.PasswordExpired)
           };
            string query = $"UPDATE {Users.TableName} SET {Users.PasswordHash.Name}=@PasswordHash, {Users.SecurityStamp.Name}=@SecurStemp," +
                $"{ Users.PasswordCreated.Name} = @PasswordCreated ,{Users.PasswordExpired.Name} = @PasswordExpired WHERE {Users.Id.Name} = @UserId";
            return db.Update(query, parameters);
        }
    }
}
