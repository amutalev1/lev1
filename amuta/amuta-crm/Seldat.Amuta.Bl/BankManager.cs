using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Transactions;
using Unity;

namespace Seldat.Amuta.BL
{
    public class BankManager
    {
        private static readonly IBaseLogger _logger;
        static BankManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        #region Managers

        static IBankDataManager _bankDataManager;
        public static IBankDataManager BankDataManager
        {
            get
            {
                if (_bankDataManager == null)
                {
                    _bankDataManager = DIManager.Container.Resolve<IBankDataManager>();

                }
                return _bankDataManager;
            }
        }

        #endregion

        public static int InsertBank(Bank bank)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int insert = -1;
                    if (bank != null)
                    {
                        insert = bank.Id;
                        if (!(bank.Id > 0))
                        {
                            insert = bank.Id = BankDataManager.InsertBank(bank);
                            //i add- check if it ok
                            if(bank.Address!=null)
                            bank.Address.Id = AddressManager.InsertAddress(bank.Address);
                        }
                    }
                    scope.Complete();
                    return insert;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Failed to insert bank", ex);
                throw;
            }
        }

        public static int UpdateBank(Bank bank)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int save = -1;
                    if (bank != null)
                    {
                        if (!(bank.Id > 0))
                            save = bank.Id = InsertBank(bank);
                        else
                        {
                            if (bank.Address != null)
                                bank.Address.Id = AddressManager.UpdateAddress(bank.Address);
                            save = BankDataManager.UpdateBank(bank);
                        }
                    }
                    scope.Complete();
                    return save;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Failed to update bank", ex);
                throw;
            }
        }

        static public Bank GetBank(int id)
        {
            try
            {
                Bank bank = BankDataManager.GetBank(id);
                bank.Address = AddressManager.GetAddress(bank.Address.Id);
                return bank;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to get bank {id}.", ex);
                throw;
            }
        }

        static public List<Bank> GetBanks()
        {
            try
            {
                List<Bank> banks = BankDataManager.GetBanks();
                return banks;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to get banks.", ex);
                throw;
            }
        }
    }
}
