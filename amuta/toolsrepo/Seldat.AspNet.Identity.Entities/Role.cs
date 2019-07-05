using Microsoft.AspNet.Identity;
using System;

namespace Seldat.AspNet.Identity.Entities
{
    public class Role : IRole
    {
        public string Id { get; set; }

        public string Name { get; set; }

        #region CTORs
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Role(string RoleName) : this()
        {
            Name = RoleName;
        }
        #endregion
    }
}
