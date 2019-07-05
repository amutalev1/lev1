using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MySql.Data.MySqlClient;
using Seldat.AspNet.Identity.Managers;
using static Seldat.AspNet.Identity.DbContent.Tables;
using Seldat.AspNet.Identity.Entities;

namespace Seldat.AspNet.Identity
{
    internal class MySQLUserRoleManager<TUser> : IUserRoleManager<TUser> where TUser : User
    {
        public CommonDbContext db = new CommonDbContext();

        public int AddToRoleAsync(TUser user, string roleId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", user.Id),
                new MySqlParameter("@RoleId", roleId)
            };
            string query = $"INSERT INTO {UserRoles.TableName} VALUES(@UserId, @RoleId)";
            return db.Insert(query, true, parameters);
        }

        public IList<string> GetRolesAsync(TUser user)
        {
            List<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@Userid",user.Id)
            };
            string query = $"select {UserRoles.RoleId.Name} from {UserRoles.TableName} where {UserRoles.UserId.Name} = @Userid";
            var dt = db.GetDataTable(query, parameters);
            IList<string> rolesList = dt?.AsEnumerable()
                                      .Select(r => r.Field<string>(UserRoles.RoleId.Name))
                                      .ToList() ?? new List<string>();
            return rolesList;
        }

        public bool IsInRoleAsync(TUser user, string roleId)
        {
            string query = $"SELECT COUNT(*) FROM {UserRoles.TableName} WHERE {UserRoles.UserId.Name} = @UserId AND {UserRoles.RoleId.Name} = @RoleId";
             List<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId",user.Id),
                new MySqlParameter("@RoleId",roleId)
            };

            object result = db.GetScalar(query, parameters);
            return int.Parse(result.ToString()) > 0;
        }

        public int RemoveFromRoleAsync(TUser user, string roleId)
        {
            string qry = $"DELETE FROM {UserRoles.TableName} WHERE {UserRoles.UserId.Name} = @UserId AND {UserRoles.RoleId.Name} = @RoleId";
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@UserId", (user as User).Id),
                new MySqlParameter("@RoleId", roleId)
            };
            return db.Delete(qry, parameters);
        }
    }
}
