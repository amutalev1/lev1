using Seldat.AspNet.Identity.Entities;

namespace Seldat.Amuta.Entities
{
    public class BranchStaff
    {
        public Branch  Branch { get; set; }
        public UserExtraDetails User { get; set; }
        public Role Role { get; set; }
    }
}
