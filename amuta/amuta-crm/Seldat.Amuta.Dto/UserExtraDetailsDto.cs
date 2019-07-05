using Seldat.Amuta.Entities;

namespace Seldat.Amuta.Dto
{
    public class UserExtraDetailsDto
    {
        public string UserId { get; set; }
        public string Identitynumber { get; set; }
        public Address Address { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}