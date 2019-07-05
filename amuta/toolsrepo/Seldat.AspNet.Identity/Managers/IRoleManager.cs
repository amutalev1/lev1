using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Seldat.AspNet.Identity.Managers
{
    /// <summary>
    /// Defines all DB operations needed to implement RoleStore. This Interface will be implemented for every DB type separately.
    /// </summary>
    internal interface IRoleManager<TRole> 
    {
        int Create(TRole role);
        int Delete(TRole role);
        TRole FindById(string roleId);
        TRole FindByName(string roleName);
        int Update(TRole role);
    }
}
