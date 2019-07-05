using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
   public class NetworkInstitution
    {
        [Required]
        public Institution Institution { get; set; }
        [Required]
        public Network Network { get; set; }
    }
}
