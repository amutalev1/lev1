using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Seldat.AspNet.Identity.DbContent.Tables;

namespace Seldat.AspNet.Identity.Managers.MySql
{
    internal class MySqlClaimManager<TUser> : IClaimManager<TUser> where TUser : User
    {


        CommonDbContext db = new CommonDbContext();

        public int AddClaim(TUser user, Claim claim)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
            new MySqlParameter("@UserId", (user as User).Id),
            new MySqlParameter("@ClaimType", claim.Type),
            new MySqlParameter("@ClaimValue", claim.Value)
        };
            var query = $"insert into {UserClaims.TableName}({UserClaims.Id.Name}, {UserClaims.ClaimType.Name}, {UserClaims.ClaimValue.Name}) values(@UserId, @ClaimType, @ClaimValue)";
            return db.Insert(query, true, parameters);
        }


        public IList<Claim> GetClaims(TUser user)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
                new MySqlParameter("@UserId",user.Id )
        };
            string query = $"select * from {UserClaims.TableName} where {UserClaims.Id.Name}=@UserId";
            var dt = db.GetDataTable(query, parameters);

            IList<Claim> claims = new List<Claim>();
            if (dt != null)
                foreach (DataRow row in dt.Rows)
                {
                    Claim userClaim = new Claim(row[UserClaims.ClaimValue.Name].ToString(), row[UserClaims.ClaimType.Name].ToString());
                    claims.Add(userClaim);
                }
            return claims;
        }

        public int RemoveClaim(TUser user, Claim claim)
        {
            IList<DbParameter> parameters = new List<DbParameter>() {
            new MySqlParameter("@UserId", user.Id),
            new MySqlParameter("@ClaimType", claim.Type),
            new MySqlParameter("@ClaimValue", claim.Value)
        };

            string query = $"delete from {UserClaims.TableName} where {UserClaims.Id.Name}= @UserId and {UserClaims.ClaimType.Name}=@ClaimType and {UserClaims.ClaimValue.Name}=@ClaimValue";
            return db.Delete(query, parameters);
        }
    }
}
