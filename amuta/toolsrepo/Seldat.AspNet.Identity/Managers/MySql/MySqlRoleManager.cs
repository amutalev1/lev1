using MySql.Data.MySqlClient;
using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static Seldat.AspNet.Identity.DbContent.Tables;

namespace Seldat.AspNet.Identity.Managers.MySql
{
    internal class MySqlRoleManager<TRole> : IRoleManager<TRole> where TRole : Role, new()
    {
        CommonDbContext db = new CommonDbContext();

        public int Create(TRole role)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@roleId", role.Id),
                new MySqlParameter("@roleName", role.Name)
            };
            string query = $"insert into {Roles.TableName} values(@roleId, @roleName)";
            return db.Insert(query, true, parameters);
        }

        public int Delete(TRole role)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@RoleId", role.Id)
            };
            string query = $"delete from {Roles.TableName} where {Roles.Id.Name}=@RoleId";
            return db.Delete(query, parameters);
        }

        public TRole FindById(string roleId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@roleId", roleId)
            };
            string query = $"select * from {Roles.TableName} where {Roles.Id.Name}=@roleId";
            DataRow row = db.GetDataRow(query, parameters);
            return Converters.DataRowToRole<TRole>(row);
        }

        public TRole FindByName(string roleName)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@roleName", roleName)
            };
            string query = $"select * from {Roles.TableName} where {Roles.Name.Name}=@roleName";
            DataRow row = db.GetDataRow(query, parameters);
            if (row == null)
                return null;
            return Converters.DataRowToRole<TRole>(row);
        }

        public int Update(TRole Role)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@roleId", Role.Id),
                new MySqlParameter("@roleName", Role.Name)
            };
            string query = $"update {Roles.TableName} set {Roles.Name.Name} = @roleName where {Roles.Id.Name} = @roleId ";
            return db.Update(query, parameters);
        }
    }
}
