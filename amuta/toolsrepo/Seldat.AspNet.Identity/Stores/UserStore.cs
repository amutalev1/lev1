using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Seldat.AspNet.Identity.Managers;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using Seldat.AspNet.Identity.Entities;

namespace Seldat.AspNet.Identity.Stores
{

    public class UserStore<TUser, TRole> : IUserStore<TUser>,
        IUserPasswordStore<TUser>,
        IUserTwoFactorStore<TUser, string>,
        IUserPhoneNumberStore<TUser>,
        IUserEmailStore<TUser>,
        IUserSecurityStampStore<TUser>,
        IUserLockoutStore<TUser, string>,
        IUserLoginStore<TUser>,
        IUserStore<TUser>,
        IUserRoleStore<TUser>,
        IQueryableUserStore<TUser> where TUser : User, new() where TRole : Role, new()
    {

        IUserManager<TUser> _userManager;
        IUserPassManager<TUser> _userPassManager;
        ILoginManager<TUser> _loginManager;
        IClaimManager<TUser> _claimManager;
        IUserRoleManager<TUser> _userRoleManager;
        public IQueryable<TUser> Users { get; }

        #region CTORs
        public UserStore(CommonDbContext dbContext)
        {
            _userManager = Managers.ManagersFactory<TUser, TRole>.GetFactory().UserManager;
            _userPassManager = Managers.ManagersFactory<TUser, TRole>.GetFactory().UserPassManager;
            _loginManager = Managers.ManagersFactory<TUser, TRole>.GetFactory().LoginManager;
            _claimManager = Managers.ManagersFactory<TUser, TRole>.GetFactory().ClaimManager;
            _userRoleManager = Managers.ManagersFactory<TUser, TRole>.GetFactory().UserRoleManager;

        }
        #endregion


        public async Task CreateAsync(TUser user)
        {
            await Task.FromResult(_userManager.CreateUser(user));
        }

        public async Task DeleteAsync(TUser user)
        {
            await Task.FromResult(_userManager.DeleteUser(user));
        }

        public void Dispose() { }

        public async Task<TUser> FindByIdAsync(string userId)
        {
            return await Task.FromResult(_userManager.GetUserById(userId));
        }

        public async Task<TUser> FindByNameAsync(string userName)
        {
            return await Task.FromResult(_userManager.GetUserByName(userName));
        }

        public async Task UpdateAsync(TUser user)
        {
            await Task.FromResult(_userManager.UpdateUser(user));
        }

        public async Task IncrementAccessFailedCount(TUser user)
        {
            await Task.FromResult(_userManager.IncrementAccessFailedCount(user));
        }

        public async Task<bool> GetLockoutEnabled(TUser user)
        {
            return await Task.FromResult(user.LockoutEnabled);
        }

        public async Task<int> GetAccessFailedCount(TUser user)
        {
            return await Task.FromResult(user.AccessFailedCount);
        }

        public async Task ResetAccessFailedCount(TUser user)
        {
            await Task.FromResult(_userManager.ResetAccessFailedCount(user));
        }

        public async Task SetLockoutEnabled(TUser user, bool enabled)
        {
            await Task.Run(() => user.LockoutEnabled = enabled);
        }

        public async Task SetLockoutEndDate(TUser user, DateTimeOffset lockoutEnd)
        {
            await Task.Run(() => _userManager.SetLockoutEndDate(user,lockoutEnd.UtcDateTime));
        }
        public async Task<string> GetPasswordHashAsync(TUser user)
        {
            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(TUser user)
        {
            return await Task.FromResult(_userPassManager.HasPasswordAsync(user));
        }

        public async Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            await Task.FromResult(user.PasswordHash = passwordHash);

        }
        public async Task<string> GetPhoneNumberAsync(TUser user)
        {
            return await Task.FromResult(user.PhoneNumber);
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
        {
            return await Task.FromResult(user.PhoneNumberConfirmed);
        }

        public async Task SetPhoneNumberAsync(TUser user, string phoneNumber)
        {
            await Task.Run(() => user.PhoneNumber = phoneNumber);
        }

        public async Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed)
        {
            await Task.Run(() => user.PhoneNumberConfirmed = confirmed);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            return await Task.FromResult(_loginManager.GetLogins(user));
        }

        public async Task<TUser> FindAsync(UserLoginInfo login)
        {
            return await Task.Run(() => _loginManager.Find(login));
        }

        public async Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            await Task.Run(() => { _loginManager.AddLogin(user, login); });
        }
        public async Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            await Task.Run(() => { _loginManager.RemoveLogin(user, login); });
        }

        public async Task<int> GetAccessFailedCountAsync(TUser user)
        {
            return await Task.FromResult(user.AccessFailedCount);
        }

        public async Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            return await Task.FromResult(user.LockoutEnabled);
        }

        public async Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            return await Task.FromResult(new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc, DateTimeKind.Utc)));
        }

        public async Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            return await Task.FromResult(_userManager.IncrementAccessFailedCount(user));
        }

        public async Task ResetAccessFailedCountAsync(TUser user)
        {
            await Task.Run(() => { _userManager.ResetAccessFailedCount(user); });
        }

        public async Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            await Task.Run(() => user.LockoutEnabled = enabled);
        }

        public async Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            await Task.Run(() => user.LockoutEndDateUtc = lockoutEnd.UtcDateTime);
        }

        public async Task<TUser> FindByEmailAsync(string email)
        {
            return await Task.FromResult(_userManager.FindByEmail(email));
        }

        public async Task<string> GetEmailAsync(TUser user)
        {
            return await Task.FromResult(user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            return await Task.FromResult(user.EmailConfirmed);
        }

        public async Task SetEmailAsync(TUser user, string email)
        {
            await Task.Run(() => user.Email = email);
        }

        public async Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            await Task.Run(() => user.EmailConfirmed = confirmed);
        }

        public async Task<string> GetSecurityStampAsync(TUser user)
        {
            return await Task.FromResult(user.SecurityStamp);
        }

        public async Task SetSecurityStampAsync(TUser user, string stamp)
        {
            await Task.Run(() => user.SecurityStamp = stamp);
        }

        public async Task<bool> GetTwoFactorEnabledAsync(TUser user)
        {
            return await Task.FromResult(user.TwoFactorEnabled);
        }

        public async Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
        {
            await Task.Run(() => user.TwoFactorEnabled = enabled);
        }

        public async Task AddClaimAsync(TUser user, Claim claim)
        {
            await Task.Run(() => { _claimManager.AddClaim(user, claim); });
        }

        public async Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            return await Task.FromResult(_claimManager.GetClaims(user));
        }

        public async Task RemoveClaimAsync(TUser user, Claim claim)
        {
            await Task.Run(() => { _claimManager.RemoveClaim(user, claim); });
        }

        public async Task<IList<string>> GetRolesAsync(TUser user)
        {
            return await Task.FromResult((_userRoleManager.GetRolesAsync(user)) as IList<string>);
        }

        public async Task<bool> IsInRoleAsync(TUser user, string roleId)
        {
            return await Task.FromResult(bool.Parse(_userRoleManager.IsInRoleAsync(user, roleId).ToString()));
        }

        public async Task RemoveFromRoleAsync(TUser user, string roleId)
        {
            await Task.FromResult(_userRoleManager.RemoveFromRoleAsync(user, roleId));
        }

        public async Task AddToRoleAsync(TUser user, string roleId)
        {
            await Task.FromResult(_userRoleManager.AddToRoleAsync(user, roleId));
        }

    }
}
