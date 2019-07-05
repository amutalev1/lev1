using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using System;

namespace Seldat.AspNet.Identity.Managers {
    internal abstract class ManagersFactory<TUser, TRole> where TUser : User, new() where TRole : Role, new() {
        public abstract IUserManager<TUser> UserManager { get; }
        public abstract IRoleManager<TRole> RoleManager { get; }
        public abstract ILoginManager<TUser> LoginManager { get; }
        public abstract IClaimManager<TUser> ClaimManager { get; }


        public abstract IUserRoleManager<TUser> UserRoleManager { get; }

        public abstract IUserPassManager<TUser> UserPassManager { get; }

        public static ManagersFactory<TUser, TRole> GetFactory() {
            switch (CommonDbContext.DataProvider) {
                case "MySql.Data.MySqlClient":
                    return new MySql.MySqlManagersFactory<TUser, TRole>();
                case "System.Data.SqlClient":
                    return new MySql.MySqlManagersFactory<TUser, TRole>();

            }
            throw new NotSupportedException(String.Format("Data provider {0} not supported", CommonDbContext.DataProvider));
        }
    }
}
