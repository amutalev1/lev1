using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlLoanDataManager:ILoanDataManager
    {

        private CommonDbContext _dbContext = null;

        public MySqlLoanDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        public int InsertLoan(LoanSupportRequest loan)
        {

            IList<DbParameter> parameters = new List<DbParameter>()
           {
               //new MySqlParameter("@account_number",student.AccountNumber!=null?student.AccountNumber:null),
               //new MySqlParameter("@first_name",student.FirstName),
               //new MySqlParameter("@last_name",student.LastName),
               //new MySqlParameter("@address_id",student.Address.Id),
               //new MySqlParameter("@bank_id", student.Bank.Id),
               //new MySqlParameter("@born_date", student.BornDate),
               //new MySqlParameter("@cellphone_number", student.CellphoneNumber!=null?student.CellphoneNumber:null),
               //new MySqlParameter("@children_number", student.ChildrenNumber!=null?student.ChildrenNumber:null),
               //new MySqlParameter("@fax_number", student.FaxNumber!=null?student.FaxNumber:null),
               //new MySqlParameter("@id_card", student.IdCard),
               //new MySqlParameter("@identity_number", student.IdentityNumber),
               //new MySqlParameter("@image", student.Image),
               //new MySqlParameter("@job_wife", student.JobWife!=null?student.JobWife:null),
               //new MySqlParameter("@married_children_number",student.MarriedChildrenNumber!=null?student.MarriedChildrenNumber:null),
               //new MySqlParameter("@monthly_income", student.MonthlyIncome!=null?student.MonthlyIncome:null),
               //new MySqlParameter("@travel_expenses", student.TravelExpenses!=null?student.TravelExpenses:null),
               //new MySqlParameter("@wife_name", student.WifeName!=null?student.WifeName:null),
               //new MySqlParameter("@phone_number", student.PhoneNumber),
               //new MySqlParameter("@travel_expenses_currency",student.TravelExpensesCurrency!=null?student.TravelExpensesCurrency:null),
               //new MySqlParameter("@monthly_income_currency",student.MonthlyIncomeCurrency!=null?student.MonthlyIncomeCurrency:null),
               //new MySqlParameter("@is_active", student.IsActive)
           };

            return _dbContext.Insert(Tables.Students.InsertTable, true, parameters);
        }


        public LoanSupportRequests GetAllLoans(int? from, int? amount)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@fromRow",from),
                new MySqlParameter("@amount",amount)
            };
            string limitStatement = string.Empty;
            if (from != null && amount != null)
            {
                limitStatement += $" Limit @fromRow, @amount ";
            }
            string sql = $"SELECT * FROM {Tables.LoanSupportRequest.TableName};";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return LoanConverter.TableToLoan(table);
            return new LoanSupportRequests();
        }

       
    }
}
