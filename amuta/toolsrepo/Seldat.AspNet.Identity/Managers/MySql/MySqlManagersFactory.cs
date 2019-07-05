
using Seldat.AspNet.Identity.Entities;

namespace Seldat.AspNet.Identity.Managers.MySql
{
    internal class MySqlManagersFactory<TUser, TRole> : ManagersFactory<TUser, TRole> where TUser : User, new() where TRole : Role, new()
    {
        public override IUserManager<TUser> UserManager { get { return new MySqlUserManager<TUser>(); } }

        public override IRoleManager<TRole> RoleManager { get { return new MySqlRoleManager<TRole>(); } }

        public override ILoginManager<TUser> LoginManager { get { return new MySqlLoginManager<TUser>(); } }

        public override IClaimManager<TUser> ClaimManager { get { return new MySqlClaimManager<TUser>(); } }

        public override IUserRoleManager<TUser> UserRoleManager { get { return new MySQLUserRoleManager<TUser>(); } }

        public override IUserPassManager<TUser> UserPassManager { get { return new MySqlUserPassManager<TUser>(); } }
    }
}
