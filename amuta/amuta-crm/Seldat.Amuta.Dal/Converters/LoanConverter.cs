using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seldat.Amuta.Entities;
using System.Data;
using Seldat.Connectivity;
using Unity;
using static Seldat.Amuta.Dal.DbContent;



namespace Seldat.Amuta.Dal.Converters
{
    class LoanConverter
    {
        private static IBaseLogger _logger;
        static LoanConverter()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        public static LoanSupportRequest RowToLoan(IEnumerable<DataRow> rows)
        {
            DataRow row = rows.FirstOrDefault();

            return new LoanSupportRequest()
            {
                AmountRepaymentMonthly = DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.AmountRepaymentMonthly.Name),
                AmountRequested = DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.AmountRequested.Name),
                ApprovedAmount = DataRowHelper.GetValue<decimal>(row, Tables.LoanSupportRequest.ApprovedAmount.Name),
                branch = new Branch() { Id = DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.BranchId.Name) },
                CurrentStatus = DataRowHelper.GetValue<RequestStatus>(row, Tables.LoanSupportRequest.CurrentStatusId.Name),
                Date = DataRowHelper.GetValue<DateTime>(row, Tables.LoanSupportRequest.Date.Name),
                DateReturningEntireAmount = DataRowHelper.GetValue<DateTime>(row, Tables.LoanSupportRequest.DateReturningEntireAmount.Name),
                Details = DataRowHelper.GetValue<string>(row, Tables.LoanSupportRequest.Details.Name),
                DigitalSignature = DataRowHelper.GetValue<byte[]>(row, Tables.LoanSupportRequest.DigitalSignature.Name),
                Id = DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.Id.Name),
                IsApproved = DataRowHelper.GetValue<bool?>(row, Tables.LoanSupportRequest.IsApproved.Name),
                Iscanceled = DataRowHelper.GetValue<bool?>(row, Tables.LoanSupportRequest.IsCanceled.Name),
                IsDisapprovedClosedRequest = DataRowHelper.GetValue<bool>(row, Tables.LoanSupportRequest.IsDisapprovedClosedRequest.Name),
                NumberApprovedMonths = DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.NumberApprovedMonths.Name),
                ReasonIsApproved = DataRowHelper.GetValue<string>(row, Tables.LoanSupportRequest.ReasonIsApproved.Name),
                Student = new Student() { Id = DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.StudentId.Name) },
  
            };
        }

        public static LoanSupportRequests TableToLoan(DataTable table)
        {
            if (table == null)
                return null;
            LoanSupportRequests loans = new LoanSupportRequests();
            var loanList = table.AsEnumerable().GroupBy(row => DataRowHelper.GetValue<int>(row, Tables.LoanSupportRequest.Id.Name),
                 (key, group) => RowToLoan(group));
            loans.AddRange(loanList.ToList());
            return loans;
        }
    }
}
