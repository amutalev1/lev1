using Seldat.AspNet.Identity.Entities;

namespace Seldat.Amuta.Dto
{
    public class BranchStaffDto
    {
        //TO DO check wich details we need about the user
        public int  BranchId { get; set; }
        public UserExtraDetailsDto User { get; set; }
        public Role Role { get; set; }
    }
}
