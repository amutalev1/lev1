﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers {
   internal interface IGeneratePassword {
       string GuidPassword();
    }
}