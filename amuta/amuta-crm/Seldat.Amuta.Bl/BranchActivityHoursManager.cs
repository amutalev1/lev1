using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using Unity;
namespace Seldat.Amuta.BL
{
    //TO DO check if used
    public class BranchActivityHoursManager
    {
        private static readonly IBaseLogger _logger;
        static BranchActivityHoursManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        #region Managers

        static IBranchActivityHoursDataManager _branchActivityHoursDataManager;
        public static IBranchActivityHoursDataManager BranchActivityHoursDataManager
        {
            get
            {
                if (_branchActivityHoursDataManager == null)
                {
                    _branchActivityHoursDataManager = DIManager.Container.Resolve<IBranchActivityHoursDataManager>();
                }
                return _branchActivityHoursDataManager;
            }
        }

        #endregion
        public static List<BranchActivityHours> GetBranchsActivityHoursByBranch(int id)
        {
            try
            {
                List<BranchActivityHours> branchActivityHours = BranchActivityHoursDataManager.GetBranchActivityHours(id);
                return branchActivityHours;
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to get branchActivityHours");
                throw;
            }

        }
        public static int Insert(BranchActivityHours branchActivityHours)
        {
            try
            {
                int rowEffected = 0;
                rowEffected = BranchActivityHoursDataManager.InsertBranchActivityHours(branchActivityHours);
                return rowEffected;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
