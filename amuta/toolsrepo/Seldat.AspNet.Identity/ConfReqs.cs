using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity
{

    public enum CnfTypes { Email, Phone };

    public class ConfReqs
    {
        public string UseId { get; set; }

        public string ConfirmationCode { get; set; }

        public DateTime CodeExp { get; set; }

        public CnfTypes ConfType { get; set; }
    }
}
