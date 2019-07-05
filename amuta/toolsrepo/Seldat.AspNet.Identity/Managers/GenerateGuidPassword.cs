using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers {
   public class GenerateGuidPassword : IGeneratePassword {
        
        public string GuidPassword() {
            return Guid.NewGuid().ToString();
        }
    }
}
