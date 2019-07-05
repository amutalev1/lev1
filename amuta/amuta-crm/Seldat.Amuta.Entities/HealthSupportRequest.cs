using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{

    public enum FamilyRelation
    {
        Wife,
        Son,
        Daughter
    }

    public  class HealthSupportRequest:BaseSupport
    {
        public string PatientName { get; set; }
        public FamilyRelation PatientFamilyRelation { get; set; }
        public int Age { get; set; }

        //TODO ask gadi-for all supports:
        //public string ReasonForIsApproved { get; set; }
        //public string DisapprovedClosedRequest { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public DateTime? RealizationDate { get; set; }
        public byte[] DigitalSignature { get; set; }


    }
}
