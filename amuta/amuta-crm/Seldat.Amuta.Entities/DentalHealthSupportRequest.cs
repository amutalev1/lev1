using System;

namespace Seldat.Amuta.Entities
{
    public class DentalHealthSupportRequest:BaseSupport
    {       
        public int? VoucherNumber { get; set; }
        public DateTime? RealizationDate { get; set; }
        public string PatientName { get; set; }
        public decimal Age { get; set; }
        public FamilyRelation PatientFamilyRelation { get; set; }  
        public byte[] DigitalSignature { get; set; }
    }
}
