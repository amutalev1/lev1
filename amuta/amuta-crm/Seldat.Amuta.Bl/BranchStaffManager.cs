using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Transactions;
using Unity;
namespace Seldat.Amuta.BL
{
    public  class branchStaffManager
    {
        private static readonly IBaseLogger _logger;
        static branchStaffManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        #region Managers
        static IUserExtraDetailsDataManager _userExtraDetailsDataManager;
        public static IUserExtraDetailsDataManager UserExtraDetailsDataManager
        {
            get
            {
                if (_userExtraDetailsDataManager == null)
                {
                    _userExtraDetailsDataManager = DIManager.Container.Resolve<IUserExtraDetailsDataManager>();
                }
                return _userExtraDetailsDataManager;
            }
        }

        static IBranchStaffDataManager _branchStaffDataManager;
        public static IBranchStaffDataManager BranchStaffDataManager
        {
            get
            {
                if (_branchStaffDataManager == null)
                {
                    _branchStaffDataManager = DIManager.Container.Resolve<IBranchStaffDataManager>();
                }
                return _branchStaffDataManager;
            }
        }
        #endregion

        //public static List<BranchStaff> GetBranchsStaffByBranch(int id)
        //{
        //    try
        //    {
        //        List<BranchStaff> branchStaff = BranchStaffDataManager.GetBranchStaffByBranchId(id);
        //        foreach (var staff in branchStaff)
        //        {
        //            staff.User = UserExtraDetailsDataManager.GetUserDetails(staff.User.us);
        //           //TO Do get the role
        //        }
        //        return branchStaff;
        //    }
        //    catch (Exception)
        //    {
        //        _logger.Debug($"Failed to get branchs");
        //        throw;
        //    }

        //}
    }
}
