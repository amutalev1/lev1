using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
   public class ExamRules
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        [Required]
        public bool IsRequiredExams { get; set; }
        [Required]
        public int ExamsPerPeriod { get; set; }
        [Required]
        public string ExamsPeriod { get; set; }
    }
}
