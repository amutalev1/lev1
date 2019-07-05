using Seldat.AspNet.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seldat.AspNet.Identity.DbContent.Tables;

namespace Seldat.AspNet.Identity.Managers
{
    public static class Converters
    {
        public static TUser DataRowToUser<TUser>(DataRow row) where TUser : User, new()
        {
            TUser user = new TUser();

            user.Id = row[Users.Id.Name].ToString();
            user.UserName = row[Users.UserName.Name].ToString();
            if (!String.IsNullOrEmpty(row[Users.Email.Name].ToString()))
                user.Email = row[Users.Email.Name].ToString();
            if (!string.IsNullOrEmpty(row[Users.Email.Name].ToString()))
                user.EmailConfirmed = Convert.ToBoolean(row[Users.EmailConfirmed.Name].ToString());
            if (!String.IsNullOrEmpty(row[Users.PasswordHash.Name].ToString()))
                user.PasswordHash = row[Users.PasswordHash.Name].ToString();
            if (!String.IsNullOrEmpty(row[Users.SecurityStamp.Name].ToString()))
                user.SecurityStamp = row[Users.SecurityStamp.Name].ToString();
            if (!String.IsNullOrEmpty(row[Users.PhoneNumber.Name].ToString()))
                user.PhoneNumber = row[Users.PhoneNumber.Name].ToString();
            if (!String.IsNullOrEmpty(row[Users.PhoneNumberConfirmed.Name].ToString()))
                user.PhoneNumberConfirmed = Convert.ToBoolean(row[Users.PhoneNumberConfirmed.Name]);
            if (!String.IsNullOrEmpty(row[Users.TwoFactorEnabled.Name].ToString()))
                user.TwoFactorEnabled = Convert.ToBoolean(row[Users.TwoFactorEnabled.Name]);
            if (!String.IsNullOrEmpty(row[Users.LockoutEndDateUtc.Name].ToString()))
                user.LockoutEndDateUtc = Convert.ToDateTime(row[Users.LockoutEndDateUtc.Name]).ToUniversalTime();
            if (!String.IsNullOrEmpty(row[Users.PasswordCreated.Name].ToString()))
                user.PasswordCreated = Convert.ToDateTime(row[Users.PasswordCreated.Name]).ToUniversalTime(); ;
            if (!String.IsNullOrEmpty(row[Users.PasswordExpired.Name].ToString()))
                user.PasswordExpired = Convert.ToDateTime(row[Users.PasswordExpired.Name]).ToUniversalTime();
            if (!String.IsNullOrEmpty(row[Users.LockoutEnabled.Name].ToString()))
                user.LockoutEnabled = Convert.ToBoolean(row[Users.LockoutEnabled.Name].ToString());
            if (!String.IsNullOrEmpty(row[Users.AccessFailedCount.Name].ToString()))
                user.AccessFailedCount = int.Parse(row[Users.AccessFailedCount.Name].ToString());
            return user;
        }

        public static TRole DataRowToRole<TRole>(DataRow row) where TRole : Role, new()
        {
            TRole role = new TRole();
            role.Id = row[Roles.Id.Name].ToString();
            role.Name = row[Roles.Name.Name].ToString();
            return role;
        }
    }
}
