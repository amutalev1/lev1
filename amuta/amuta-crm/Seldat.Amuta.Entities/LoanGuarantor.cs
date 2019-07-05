using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
  public  class LoanGuarantor
    {
        public LoanSupportRequest Loan { get; set; }
        public Guarantor Guarantor { get; set; }
    }
}
