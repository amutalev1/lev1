//using Seldat.Amuta.Entities;
//using Seldat.Amuta.Entities.Managers;
//using Seldat.Utils;
//using System;
//using System.Collections.Generic;
//using Unity;
//namespace Seldat.Amuta.BL
//{
//  public  class branchProcedureManager
//    {

//        private static readonly IBaseLogger _logger;
//        static branchProcedureManager()
//        {
//            _logger = DIManager.Container.Resolve<IBaseLogger>();
//        }
//        #region Managers
//        static IBranchRulesDataManager _branchProcedureDataManager;
//        public static IBranchRulesDataManager BranchProcedureDataManager
//        {
//            get
//            {
//                if (_branchProcedureDataManager == null)
//                {
//                    _branchProcedureDataManager = DIManager.Container.Resolve<IBranchRulesDataManager>();
//                }
//                return _branchProcedureDataManager;
//            }
//        }
//        #endregion
//        public static BranchProcedure GetBranchProcedureByBranchId(int id)
//        {
//            try
//            {
//                return BranchProcedureDataManager.GetBranchProcedureByBranchId(id);
//            }
//            catch (Exception)
//            {
//                _logger.Debug($"Failed to get branch procedures");
//                throw;
//            }

//        }
//        public static int Insert(BranchProcedure branchProcedure)
//        {
//            try
//            {
//                int rowEffected = 0;
//                rowEffected = BranchProcedureDataManager.InsertBranchProcedure(branchProcedure);
//                return rowEffected;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//    }

//}
