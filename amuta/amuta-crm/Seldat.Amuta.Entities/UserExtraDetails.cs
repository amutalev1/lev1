using Seldat.AspNet.Identity.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Seldat.Amuta.Entities
{
    //to do--- have to be inneritance from user what with the mail property?
    public class UserExtraDetails 
    {
        public string UserId { get; set; }
        [Required, StringLength(12, MinimumLength = 9, ErrorMessage = "IdentityNumber must be between 9-12 digits")]//change in db the length?
        [RegularExpression(@"[\d]{9,12}", ErrorMessage = "IdentityNumber must contain just digits, length between 9-12")]
        public string Identitynumber { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string CellphoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}