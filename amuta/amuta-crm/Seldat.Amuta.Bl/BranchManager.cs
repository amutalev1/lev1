using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity;
namespace Seldat.Amuta.BL
{
    public class BranchManager
    {
        private static readonly IBaseLogger _logger;
        static BranchManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        #region Managers

        static IBranchDataManager _branchDataManager;
        public static IBranchDataManager BranchDataManager
        {
            get
            {
                if (_branchDataManager == null)
                {
                    _branchDataManager = DIManager.Container.Resolve<IBranchDataManager>();
                }
                return _branchDataManager;
            }
        }

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
        static IBranchRulesDataManager _branchRulesDataManager;
        public static IBranchRulesDataManager BranchRulesDataManager
        {
            get
            {
                if (_branchRulesDataManager == null)
                {
                    _branchRulesDataManager = DIManager.Container.Resolve<IBranchRulesDataManager>();
                }
                return _branchRulesDataManager;
            }
        }
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
        static IBranchExamDataManager _branchExamDataManager;
        public static IBranchExamDataManager BranchExamDataManager
        {
            get
            {
                if (_branchExamDataManager == null)
                {
                    _branchExamDataManager = DIManager.Container.Resolve<IBranchExamDataManager>();
                }
                return _branchExamDataManager;
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
        static IScolarshipDataManager _scolarshipDataManager;
        public static IScolarshipDataManager ScolarshipDataManager
        {
            get
            {
                if (_scolarshipDataManager == null)
                {
                    _scolarshipDataManager = DIManager.Container.Resolve<IScolarshipDataManager>();
                }
                return _scolarshipDataManager;
            }
        }
        static IBranchTypeDataManager _branchTypeDataManager;
        public static IBranchTypeDataManager BranchTypeDataManager
        {
            get
            {
                if (_branchTypeDataManager == null)
                {
                    _branchTypeDataManager = DIManager.Container.Resolve<IBranchTypeDataManager>();
                }
                return _branchTypeDataManager;
            }
        }
        #endregion
        public static Branches GetBranchesBasicDetails(int id, Branch.Includes includes)
        {
            try
            {
                Branches branches = BranchDataManager.GetBranchesByType(id, includes);
                return branches;

            }
            catch (Exception)
            {
                _logger.Debug($"Failed to get branchs");
                throw;
            }

        }
        public static int Insert(Branch branch)
        {
            int rowsAffected = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (branch.Address != null)
                    {
                        branch.Address.Id = AddressManager.InsertAddress(branch.Address);
                    }
                    rowsAffected = BranchDataManager.InsertBranch(branch);
                    if (branch.ActivityHours != null)
                    {
                        foreach (var activityHours in branch.ActivityHours)
                        {
                            activityHours.Branch.Id = rowsAffected;
                            BranchActivityHoursDataManager.InsertBranchActivityHours(activityHours);
                        }
                    }
                    //if (branch.ExamRules != null)
                    //{
                    //    branch.ExamRules.Branch.Id = rowsAffected;
                    //    BranchRulesDataManager.InsertExamRules(branch.ExamRules);
                    //}
                    //if (branch.AttendanceRules != null)
                    //{
                    //    branch.AttendanceRules.Branch.Id = rowsAffected;
                    //    BranchRulesDataManager.InsertAttendanceRules(branch.AttendanceRules);
                    //}
                    scope.Complete();
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int Delete(Branch[] branches)
        {
            try
            {
                var numAffected = 0;
                for (int i = 0; i < branches.Length; i++)
                {
                    numAffected = BranchDataManager.Delete(branches[i]);
                }
                return numAffected;
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public static Branches Contains(Branch.Includes includes, string str)
        {
            try
            {
                Branches branches = BranchDataManager.Contains(includes, str);
                return branches;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to search branch.", ex);
                throw;
            }
        }

        public static int Update(Branch branch)
        {
            int rowsAffected = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (branch.ActivityHours != null)
                    {
                        foreach (var ActivityHours in branch.ActivityHours)
                        {
                            ActivityHours.Branch = new Branch { Id = branch.Id };
                            BranchActivityHoursDataManager.UpdateBranchActivityHours(ActivityHours);
                        }
                    }
                    if (branch.ExamRules != null)
                    {
                        branch.ExamRules.Branch = new Branch { Id = branch.Id };
                        BranchRulesDataManager.UpdateExamRules(branch.ExamRules);
                    }
                    if (branch.AttendanceRules != null)
                    {
                        branch.AttendanceRules.Branch = new Branch { Id = branch.Id };
                        BranchRulesDataManager.UpdateAttendanceRules(branch.AttendanceRules);
                    }
                    if (branch.Address != null)
                    {
                        AddressManager.UpdateAddress(branch.Address);
                    }
                    rowsAffected = BranchDataManager.UpdateBranch(branch);
                    scope.Complete();
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int MakeBranchInactive(int id)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var numAffected = BranchDataManager.MakeBranchInactive(id);
                    BranchStudentManager.MakeBranchStudentsInactive(id);
                    scope.Complete();
                    return numAffected;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Branch GetBranch(int id, Branch.Includes includes)
        {
            Branch branch = BranchDataManager.GetBranchById(id, includes);
            return branch;
        }
        public static int MakeBranchActive(int id)
        {
            try
            {
                var numAffected = BranchDataManager.MakeBranchActive(id);
                return numAffected;
            }
            catch (Exception)
            {
                throw;

            }

        }
        public static int IncreaseNumberOfStudents(int branchId)
        {
            try
            {
                int update = BranchDataManager.IncreaseNumberOfStudents(branchId);
                return update;
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to increase the number of students in branch {branchId}.");
                throw;
            }
        }
        public static int ReduceNumberOfStudents(int branchId)
        {
            try
            {
                int update = BranchDataManager.ReduceNumberOfStudents(branchId);
                return update;
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to reduce the number of students in branch {branchId}.");
                throw;
            }
        }
    }
}