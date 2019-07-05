using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Managers
{
    internal interface IClaimManager<TUser>
    {

        int AddClaim(TUser user, Claim claim);

        IList<Claim> GetClaims(TUser user);

        int RemoveClaim(TUser user, Claim claim);
    }
}
