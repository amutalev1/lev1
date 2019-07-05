using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using static Seldat.Amuta.Dal.DbContent;
using Seldat.Amuta.Entities.Managers;

namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlBankDataManager : IBankDataManager
    {
        private CommonDbContext _dbContext = null;

        public MySqlBankDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        public Bank GetBank(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };

            DataRow row = _dbContext.GetDataRow(Tables.Banks.Select, parameters);

            return BankConverter.RowToBank(row);
        }

        public List<Bank> GetBanks()
        {
            DataTable table = _dbContext.GetDataTable(Tables.Banks.SelectAllTable,null);
            if (table != null)
                return BankConverter.TableToBanks(table);
            return new List<Bank>();
        }

        public int InsertBank(Bank bank)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@bank_number", bank.BankNumber),
                new MySqlParameter("@name", bank.Name),
                new MySqlParameter("@branch_number", bank.BranchNumber),
                new MySqlParameter("@address_id", bank.Address!=null? bank.Address.Id:1),
            };
            return _dbContext.Insert(Tables.Banks.InsertTable,true,parameters);
        }

        public int UpdateBank(Bank bank)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", bank.Id),
                new MySqlParameter("@bank_number", bank.BankNumber),
                new MySqlParameter("@name", bank.Name),
                new MySqlParameter("@branch_number", bank.BranchNumber),
                new MySqlParameter("@address_id", bank.Address!=null? bank.Address.Id:1),
            };
            return _dbContext.Update(Tables.Banks.UpdateTable,parameters);
        }
    }
}
