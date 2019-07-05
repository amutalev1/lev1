using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Unity;
namespace Seldat.Amuta.Bl
{
    public class FinancialSupportManager
    {
        private static readonly IBaseLogger _logger;
        static FinancialSupportManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        #region Managers

        static IFinancialSupportDataManager _financialSupportDataManager;
        static IFinancialSupportDataManager FinancialSupportDataManager
        {
            get
            {
                if (_financialSupportDataManager == null)
                {
                    _financialSupportDataManager = DIManager.Container.Resolve<IFinancialSupportDataManager>();
                }
                return _financialSupportDataManager;
            }
        }

        #endregion
        public static int InsertFinancialSupportRequest(FinancialSupportRequest financialSupportRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //if (IFinancialSupportDataManager.IsExistIdentityNumber(student.IdentityNumber, student.Id))
                    //    throw new Exception("The identity number is already exist.");
                    //todo has to be change
                    financialSupportRequest.branch.Id = 0;
                    financialSupportRequest.Student.Id = 0;
                    int insert = financialSupportRequest.Id = FinancialSupportDataManager.InsertFinancialSupportRequest(financialSupportRequest);
                    scope.Complete();
                    return insert;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to insert finantial support", ex);
                throw;
            }
        }
        public static FinancialSupportRequests GetFinancialSupportRequests()
        {
            try
            {
                FinancialSupportRequests financialSupportRequests = FinancialSupportDataManager.GetFinancialSupports();
                return financialSupportRequests;

            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to get financialSupportRequests");
                throw;
            }

        }

    }
}
