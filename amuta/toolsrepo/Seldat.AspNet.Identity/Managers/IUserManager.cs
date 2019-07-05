using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers {
    /// <summary>
    /// Defines all DB operations needed to implement UserStore. This Interface will be implemented for every DB type separately.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    internal interface IUserManager<TUser> {

        TUser GetUserById(String Id);

        int CreateUser(TUser user);

        int DeleteUser(TUser user);

        TUser GetUserByName(String userName);

        int UpdateUser(TUser user);

        int IncrementAccessFailedCount(TUser user);

        int ResetAccessFailedCount(TUser user);

        TUser FindByEmail(string email);

        int SetLockoutEnabled(TUser user, bool enabled);

        int SetEmail(TUser user, string email) ;

        int SetEmailConfirmed(TUser user, bool confirmed);

        int SetPhoneNumberAsync(TUser user, string phoneNumber);

        int SetPhoneNumberConfirmed(TUser user, bool confirmed);

        int SetTwoFactorEnabled(TUser user, bool enabled);

        int SetLockoutEndDate(TUser user, DateTimeOffset lockoutEnd);
    }
}