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
    public class FinancialSupportConverter
    {
        private static IBaseLogger _logger;
        static FinancialSupportConverter()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        public static FinancialSupportRequest RowToFinancialSupportRequest(IEnumerable<DataRow> rows)
        {
            DataRow row = rows.FirstOrDefault();
            FinancialSupportRequests financialSupportRequests = new FinancialSupportRequests();


            return new FinancialSupportRequest()
            {
                ApprovedAmount = DataRowHelper.GetValue<int>(row, Tables.FinancialSupportRequest.ApprovedAmount.FullName),
                branch = new Branch() { Id = DataRowHelper.GetValue<int>(row, Tables.FinancialSupportRequest.BranchId.FullName) },
                Id= DataRowHelper.GetValue<int>(row, Tables.FinancialSupportRequest.Id.FullName),
                CurrentStatus= DataRowHelper.GetValue<RequestStatus>(row, Tables.FinancialSupportRequest.CurrentStatusId.FullName),
                Date= DataRowHelper.GetValue<DateTime>(row, Tables.FinancialSupportRequest.Date.FullName),
                Details= DataRowHelper.GetValue<string>(row, Tables.FinancialSupportRequest.Details.FullName),
                DigitalSignature= DataRowHelper.GetValue<Byte[]>(row, Tables.FinancialSupportRequest.DigitalSignature.FullName),
                IsApproved= DataRowHelper.GetValue<bool>(row, Tables.FinancialSupportRequest.IsApproved.FullName),
                Iscanceled= DataRowHelper.GetValue<bool>(row, Tables.FinancialSupportRequest.IsCanceled.FullName),
                NumberOfMonthsApproved= DataRowHelper.GetValue<int>(row, Tables.FinancialSupportRequest.NumberOfMonthsApproved.FullName),
                Student=new Student() { Id= DataRowHelper.GetValue<int>(row, Tables.FinancialSupportRequest.StudentId.FullName), }
            };
        }

        public static FinancialSupportRequests TableToFinancialSupport(DataTable table)
        {
            if (table == null)
                return null;
            FinancialSupportRequests financialSupports = new FinancialSupportRequests();
            var studentList = table.AsEnumerable().GroupBy(row => DataRowHelper.GetValue<int>(row, Tables.FinancialSupportRequest.Id.FullName),
                 (key, group) => RowToFinancialSupportRequest(group));
            financialSupports.AddRange(studentList.ToList());
            return financialSupports;
        }
    }
}
