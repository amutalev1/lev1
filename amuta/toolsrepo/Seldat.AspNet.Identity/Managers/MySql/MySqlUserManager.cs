using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using static Seldat.AspNet.Identity.DbContent.Tables;

namespace Seldat.AspNet.Identity.Managers.MySql
{
    internal class MySqlUserManager<TUser> : IUserManager<TUser> where TUser : User, new()
    {
        CommonDbContext db = new CommonDbContext();

        public TUser GetUserById(string Id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", Id)
            };

            string query = $"select * from {Users.TableName} where {Users.Id.Name}=@UserId";
            DataRow row = db.GetDataRow(query, parameters);
            return Converters.DataRowToUser<TUser>(row);
        }

        public int CreateUser(TUser user)
        {
            string query = $"Insert into {Users.TableName} ({Users.UserName.Name}, {Users.Id.Name}, {Users.PasswordHash.Name}, {Users.SecurityStamp.Name},{Users.Email.Name},{Users.EmailConfirmed.Name},{Users.PhoneNumber.Name},{Users.PhoneNumberConfirmed.Name}, {Users.AccessFailedCount.Name},{Users.LockoutEnabled.Name},{Users.LockoutEndDateUtc.Name},{Users.TwoFactorEnabled.Name}) " +
                $"values(@name,@id,@pwdHash,@SecStamp,@email,@emailconfirmed,@phonenumber,@phonenumberconfirmed,@accesscount,@lockoutenabled,@lockoutenddate,@twofactorenabled)";
            IList<DbParameter> parameters = new List<DbParameter>() {
            new MySqlParameter("@name", !string.IsNullOrEmpty(user.UserName) ? user.UserName :null),
            new MySqlParameter("@id", !string.IsNullOrEmpty(user.Id) ? user.Id :null),
            new MySqlParameter("@pwdHash", !string.IsNullOrEmpty(user.PasswordHash) ? user.PasswordHash :null),
            new MySqlParameter("@SecStamp", !string.IsNullOrEmpty(user.SecurityStamp) ? user.SecurityStamp :null),
            new MySqlParameter("@email", !string.IsNullOrEmpty(user.Email) ? user.Email :null),
            new MySqlParameter("@emailconfirmed", user.EmailConfirmed),
            new MySqlParameter("@phonenumber", !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber :null),
            new MySqlParameter("@phonenumberconfirmed", user.PhoneNumberConfirmed),
            new MySqlParameter("@accesscount", user.AccessFailedCount),
            new MySqlParameter("@lockoutenabled", user.LockoutEnabled),
            new MySqlParameter("@lockoutenddate", user.LockoutEndDateUtc),
            new MySqlParameter("@twofactorenabled", user.TwoFactorEnabled)
            };
            return db.Insert(query, false, parameters);
        }

        public int DeleteUser(TUser user)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", !string.IsNullOrEmpty(user.Id) ? user.Id :null)
            };
            string query = $"delete from {Users.TableName} where {Users.Id.Name}=@UserId";
            return db.Delete(query, parameters);
        }

        public TUser GetUserByName(string userName)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserName", !string.IsNullOrEmpty(userName) ? userName :null)
            };
            string query = $"select * from {Users.TableName} where {Users.UserName.Name} = @UserName";
            DataRow row = db.GetDataRow(query, parameters);
            if (row == null)
                return null;
            return Converters.DataRowToUser<TUser>(row);
        }

        public int UpdateUser(TUser user)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", !string.IsNullOrEmpty(user.Id) ? user.Id :null),
                new MySqlParameter("@UserName", !string.IsNullOrEmpty(user.UserName) ? user.UserName :null),
                new MySqlParameter("@AccessFailedCount", user.AccessFailedCount),
                new MySqlParameter("@EmailConfirmed", user.EmailConfirmed),
                new MySqlParameter("@LockoutEnabled", user.LockoutEnabled),
                new MySqlParameter("@LockoutEndDateUtc", user.LockoutEndDateUtc),
                new MySqlParameter("@PasswordHash", !string.IsNullOrEmpty(user.PasswordHash) ? user.PasswordHash :null),
                new MySqlParameter("@SecurityStamp", !string.IsNullOrEmpty(user.SecurityStamp) ? user.SecurityStamp :null),
                new MySqlParameter("@Email", !string.IsNullOrEmpty(user.Email) ? user.Email :null),
                new MySqlParameter("@TwoFactorEnabled", user.TwoFactorEnabled),
                new MySqlParameter("@PhoneNumber", !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber :null),
                new MySqlParameter("@PhoneNumberConfirmed", user.PhoneNumberConfirmed)
            };
            string query = $"UPDATE {Users.TableName} SET {Users.UserName.Name} = @UserName, {Users.AccessFailedCount.Name} = @AccessFailedCount," +
                $"{Users.EmailConfirmed.Name} = @EmailConfirmed, {Users.LockoutEnabled.Name} = @LockoutEnabled, {Users.LockoutEndDateUtc.Name} = @LockoutEndDateUtc, {Users.PasswordHash.Name} = @PasswordHash," +
                $"{Users.SecurityStamp.Name} = @SecurityStamp, {Users.Email.Name} = @Email, {Users.TwoFactorEnabled.Name} = @TwoFactorEnabled, {Users.PhoneNumber.Name} = @PhoneNumber, {Users.PhoneNumberConfirmed.Name} = @PhoneNumberConfirmed  WHERE {Users.Id.Name} = @UserId";
            return db.Update(query, parameters);
        }

        public int IncrementAccessFailedCount(TUser user)
        {
            int incAccessFailed = user.AccessFailedCount + 1;
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@incAccessFailed",incAccessFailed)

           };
            string query = $"update {Users.TableName} set {Users.AccessFailedCount.Name} = @incAccessFailed where {Users.Id.Name} = @UserId ";
            db.Update(query, parameters);
            return incAccessFailed;
        }

        public int ResetAccessFailedCount(TUser user)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", user.Id)
            };
            string query = $"update {Users.TableName} set {Users.AccessFailedCount.Name} = 0 where {Users.Id.Name} = @UserId";
            return db.Update(query, parameters);
        }

        public int SetLockoutEnabled(TUser user, bool enabled)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@enabled",enabled)

           };
            string query = $"update {Users.TableName} set {Users.LockoutEnabled.Name} = @enabled where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }

        public TUser FindByEmail(string email)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@Email", email)
            };
            string query = $"select * from {Users.TableName} where {Users.Email.Name}=@Email";
            DataRow result = db.GetDataRow(query, parameters);

            if (result == null)
                return null;
            return Converters.DataRowToUser<TUser>(result);
        }

        public int SetEmail(TUser user, string email)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@email",email)

           };
            string query = $"update {Users.TableName} set {Users.Email.Name} = @email where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }

        public int SetEmailConfirmed(TUser user, bool confirmed)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@emailConfirmed",confirmed)

           };
            string query = $"update {Users.TableName} set {Users.EmailConfirmed.Name} = @emailConfirmed where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }

        public int SetPhoneNumberAsync(TUser user, string phoneNumber)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@phoneNumber",phoneNumber)

           };
            string query = $"update {Users.TableName} set {Users.PhoneNumber.Name} = @phoneNumber where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }

        public int SetPhoneNumberConfirmed(TUser user, bool confirmed)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@confirmed",confirmed)

           };
            string query = $"update {Users.TableName} set {Users.PhoneNumberConfirmed.Name} = @confirmed where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }

        public int SetTwoFactorEnabled(TUser user, bool enabled)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@enabled",enabled)
           };
            string query = $"update {Users.TableName} set {Users.TwoFactorEnabled.Name} = @enabled where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }

        public int SetLockoutEndDate(TUser user, DateTimeOffset lockoutEnd)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@UserId", user.Id),
               new MySqlParameter("@lockoutEnd",lockoutEnd)

           };
            string query = $"update {Users.TableName} set {Users.LockoutEndDateUtc.Name} = @lockoutEnd where {Users.Id.Name} = @UserId ";
            return db.Update(query, parameters);
        }
    }
}





