using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public class BranchActivityHours
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Branch Branch { get; set; }
        [Required, DataType(DataType.Time)]
        public TimeSpan LateHour { get; set; }
        [Required, DataType(DataType.Time)]
        public TimeSpan StartStudyHours { get; set; }
        [Required, DataType(DataType.Time)]
        public TimeSpan EndStudyHours { get; set; }
    }
}
