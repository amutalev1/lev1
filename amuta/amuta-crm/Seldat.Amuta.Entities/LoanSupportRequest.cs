using System;
using System.Collections.Generic;

namespace Seldat.Amuta.Entities
{
    public class LoanSupportRequest:BaseSupport
    { 
  
        public decimal AmountRequested { get; set; }
        public decimal? AmountRepaymentMonthly { get; set; }
        public DateTime DateReturningEntireAmount { get; set; }  
        public string ReasonIsApproved { get; set; }
        public bool IsDisapprovedClosedRequest { get; set; }
        public byte[] DigitalSignature { get; set; }
        public int? NumberApprovedMonths { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public List<LoanGuarantor> LoanGuarantors { get; set; }
    }
}
