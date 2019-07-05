using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlFinancialSupportDataManager : IFinancialSupportDataManager
    {
        private CommonDbContext _dbContext = null;

        public MySqlFinancialSupportDataManager()
        {
            _dbContext = new CommonDbContext();
        }
        
        public int InsertFinancialSupportRequest(FinancialSupportRequest financialSupportRequest)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@id",financialSupportRequest.Id),
               new MySqlParameter("@approval_amount",financialSupportRequest.ApprovedAmount),
               new MySqlParameter("@branch",financialSupportRequest.branch),
               new MySqlParameter("@current_status",financialSupportRequest.CurrentStatus),
               new MySqlParameter("@date", financialSupportRequest.Date),
               new MySqlParameter("@details", financialSupportRequest.Details),
               new MySqlParameter("@digital_signature", financialSupportRequest.DigitalSignature),
               new MySqlParameter("@is_approved", financialSupportRequest.IsApproved),
               new MySqlParameter("@is_cancaled", financialSupportRequest.Iscanceled),
               new MySqlParameter("@number_of_month_approved", financialSupportRequest.NumberOfMonthsApproved),
               new MySqlParameter("@student", financialSupportRequest.Student)
           };

            return _dbContext.Insert(DbContent.Tables.FinancialSupportRequest.InsertTable, true, parameters);
        }
        public FinancialSupportRequests GetFinancialSupports()
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                
            };
            string sql = $"select * from {Tables.FinancialSupportRequest.TableName}" ;
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return FinancialSupportConverter.TableToFinancialSupport(table);
            return new FinancialSupportRequests();
        }
      
    }
}
