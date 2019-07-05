using System;


namespace Seldat.Amuta.Entities
{
   public class FinancialSupportRequest:BaseSupport
    {   
        public decimal? ApprovedAmount { get; set; }
        public int? NumberOfMonthsApproved { get; set; } 
        public byte[] DigitalSignature { get; set; }
    }
}
