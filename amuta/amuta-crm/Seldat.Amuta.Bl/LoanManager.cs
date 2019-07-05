using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Amuta.Entities.Validations;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;
using Unity;



namespace Seldat.Amuta.BL
{
    public class LoanManager
    {

        static ILoanDataManager _loanDataManager;
        static ILoanDataManager LoanDataManager
        {
            get
            {
                if (_loanDataManager == null)
                {
                    _loanDataManager = DIManager.Container.Resolve<ILoanDataManager>();
                }
                return _loanDataManager;
            }
        }


        private static readonly IBaseLogger _logger;
        static LoanManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        public static int InsertLoan(LoanSupportRequest loan)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    
                    int insert = LoanDataManager.InsertLoan(loan);               
                    scope.Complete();
                    return insert;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to insert pending student.", ex);
                throw;
            }
        }

        public static LoanSupportRequests GetLoans(int? from, int? amount)
        {
            try
            {
                LoanSupportRequests loans = LoanDataManager.GetAllLoans(from, amount);
                return loans;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load loans.", ex);
                throw;
            }
        }


    }
}
