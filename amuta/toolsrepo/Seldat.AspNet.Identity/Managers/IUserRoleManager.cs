using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers
{
    internal interface IUserRoleManager<TUser>
    {
        int AddToRoleAsync(TUser user, string roleId);


        IList<string> GetRolesAsync(TUser user);


        bool IsInRoleAsync(TUser user, string roleId);


        int RemoveFromRoleAsync(TUser user, string roleId);
       
    }
}
