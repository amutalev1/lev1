using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class StudentPaymentConverter
    {
        private static IBaseLogger _logger;
        static StudentPaymentConverter()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        public static StudentPayment RowToStudentPayment(IEnumerable<DataRow> rows)
        {
            DataRow row = rows.FirstOrDefault();          
            
            return new StudentPayment()
            {
              AttendanceSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.AttendanceSum.Name),
              DentalHealthSupportSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.DentalHealthSupportSum.Name),
              ExamsSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.ExamsSum.Name),
              FinancialSupportSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.FinancialSupportSum.Name),
              HealthSupportSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.HealthSupportSum.Name),
              LoansGivenSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.LoansGivenSum.Name),
              LoansReturnSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.LoansReturnSum.Name),
              Month= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.Month.Name),
              PaymentSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.PaymentSum.Name),
              StateBudgetSum= DataRowHelper.GetValue<int>(row, Tables.StudentPayment.StateBudgetSum.Name),
              Student = new Student() { Id = DataRowHelper.GetValue<int>(row, Tables.StudentPayment.studentId.Name) },
              // Student= DataRowHelper.GetValue<Student>(row, Tables.StudentPayment.Student.Name),
              Year = DataRowHelper.GetValue<int>(row, Tables.StudentPayment.Year.Name)
            };
        }

        public static StudentPayments TableToStudentPayments(DataTable table)
        {
            if (table == null)
                return null;
            StudentPayments studentPayments = new StudentPayments();
            var studentPaymentList = table.AsEnumerable().GroupBy(row => DataRowHelper.GetValue<int>(row, Tables.StudentPayment.Id.Name),
                 (key, group) => RowToStudentPayment(group));
            studentPayments.AddRange(studentPaymentList.ToList());
            return studentPayments;
        }
    }
}

