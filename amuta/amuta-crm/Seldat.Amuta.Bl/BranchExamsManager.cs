using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using Unity;
namespace Seldat.Amuta.BL
{
    //TO DO check if used
    public class BranchExamsManager
    {
        private static readonly IBaseLogger _logger;
        static BranchExamsManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        #region Managers
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
        #endregion
        public static List<BranchExam> GetBranchExamsBybranchId(int id)
        {
            try
            {
                return BranchExamDataManager.GetBranchExamsByBranchId(id);
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to get branch Exams");
                throw;
            }

        }
        public static List<BranchExam> GetExams()
        {
            try
            {
                return BranchExamDataManager.GetExams();
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to get  Exams");
                throw;
            }

        }

        public static int Insert(BranchExam branchExam)
        {
            try
            {
                int rowEffected = 0;
                rowEffected = BranchExamDataManager.InsertBranchExam(branchExam);
                return rowEffected;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}