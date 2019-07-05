using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
   public class Guarantor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string IdCard { get; set; }
        public byte[] DigitalSignature { get; set; }
        public DateTime GuaranteeDeedWritingDate { get; set; }
        public string LoanNote { get; set; }
    }
}
