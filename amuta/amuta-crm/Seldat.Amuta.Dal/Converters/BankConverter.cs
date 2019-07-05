using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
   public class BankConverter
    {
        internal static Bank RowToBank(DataRow row)
        {
            return new Bank()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Banks.Id.FullName),
                BankNumber = DataRowHelper.GetValue<string>(row, Tables.Banks.BankNumber.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.Banks.Name.FullName),
                BranchNumber = DataRowHelper.GetValue<string>(row, Tables.Banks.BranchNumber.FullName),
                //Address = new Address() { Id = DataRowHelper.GetValue<int>(row, Tables.Banks.AddressId.FullName) }
            };
        }

        public static List<Bank> TableToBanks(DataTable table)
        {
            List<Bank> banks = new List<Bank>();
            Bank bank = new Bank();
            foreach (DataRow row in table.Rows)
            {
                bank = RowToBank(row);
                banks.Add(bank);
            }
            return banks;
        }
    }
}