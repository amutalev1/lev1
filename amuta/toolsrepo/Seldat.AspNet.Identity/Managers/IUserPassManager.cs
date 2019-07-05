using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers
{
    internal interface IUserPassManager<TUser>
    {
        string GetPasswordHashAsync(TUser user);

        bool HasPasswordAsync(TUser user);

        int SetPasswordHashAsync(TUser user, string passwordHash);

        int SetPasswordValidity(TUser user, int expired);

        int UpdateAsync(TUser user);

    }
}
