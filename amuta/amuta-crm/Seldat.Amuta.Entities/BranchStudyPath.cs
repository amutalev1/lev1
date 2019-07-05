using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
    class BranchStudyPath
    {
        public int Id { get; set; }
        [Required]
        public Branch Branch { get; set; }
        [Required]
        public StudyPath StudyPath { get; set; }
    }
}
