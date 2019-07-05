using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers {
    internal  interface ILoginManager<TUser> {

        int AddLogin(TUser user, UserLoginInfo login);

        int RemoveLogin(TUser user, UserLoginInfo login);

        IList<UserLoginInfo> GetLogins(TUser user);

        TUser Find(UserLoginInfo login);
    }
}
