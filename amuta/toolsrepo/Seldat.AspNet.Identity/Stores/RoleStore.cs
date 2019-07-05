
using Microsoft.AspNet.Identity;
using Seldat.AspNet.Identity.Entities;
using Seldat.AspNet.Identity.Managers;
using Seldat.Connectivity;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Stores
{
    public class RoleStore<TUser,TRole> : IRoleStore<TRole> where TUser:User,new() where TRole : Role, new()
    {
        private IRoleManager<TRole> _roleManager;

        #region CTORs
        public RoleStore(CommonDbContext dbContext)
        {
            _roleManager = Managers.ManagersFactory<TUser, TRole>.GetFactory().RoleManager;
        }
        #endregion

        public async Task CreateAsync(TRole role)
        {
            await Task.FromResult(_roleManager.Create(role));
        }

        public async Task DeleteAsync(TRole role)
        {
            await Task.FromResult(_roleManager.Delete(role));
        }

        public void Dispose() { }

        public async Task<TRole> FindByIdAsync(string RoleId)
        {
            return await Task.FromResult(_roleManager.FindById(RoleId));
        }

        public async Task<TRole> FindByNameAsync(string RoleName)
        {
            return await Task.FromResult(_roleManager.FindByName(RoleName));
        }

        public async Task UpdateAsync(TRole role)
        {
            await Task.FromResult(_roleManager.Update(role));
        }
    }
}
