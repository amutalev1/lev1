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
    public class MySqlStudentPaymentDataManager:IStudentPaymentDataManager
    {
       
        private CommonDbContext _dbContext = null;        
        public MySqlStudentPaymentDataManager()
        {
            _dbContext = new CommonDbContext();
        }
        public StudentPayments GetAllPayments(int? from, int? amount)
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
           string sql= $"SELECT * FROM {Tables.StudentPayment.TableName}";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentPaymentConverter.TableToStudentPayments(table);
            return new StudentPayments();
        }


    }
}
