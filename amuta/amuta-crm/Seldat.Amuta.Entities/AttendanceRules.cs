using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
   public class AttendanceRules
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "MaximumLateness hours can must be greater than 0")]
        public int MaximumLateness { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "MaximumAbsences hours can must be greater than 0")]
        public int MaximumAbsences { get; set; }
    }
}
