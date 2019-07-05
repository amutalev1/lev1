using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.AspNet.Identity.Entities {
    public class User : IUser {


        #region CTORs
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string username,
            string email,
            bool emailConfirmed,
            string passwordHash,
            string securityStamp,
            string phoneNumber,
            bool phoneNumberConfirmed,
            bool twoFactoryEnabled,
            DateTime lockoutEndDateUtc,
            bool lockoutEnabled,
            int accessFailedCount) : this()
        {
            UserName = username;
            Email = email;
            EmailConfirmed = emailConfirmed;
            PasswordHash = passwordHash;
            SecurityStamp = securityStamp;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumberConfirmed;
            TwoFactorEnabled = twoFactoryEnabled;
            LockoutEndDateUtc = lockoutEndDateUtc;
            LockoutEnabled = lockoutEnabled;
            AccessFailedCount = accessFailedCount;
        }

        #endregion

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTime PasswordCreated { get; set;  }

        public DateTime PasswordExpired { get; set; }
    }
}
