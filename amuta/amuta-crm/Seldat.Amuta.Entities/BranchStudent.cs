using System;
using System.ComponentModel.DataAnnotations;


namespace Seldat.Amuta.Entities
{
    public enum StatusInBranch
    {
        Pending=1,
        Approved=2
    }
    public class BranchStudent
    {  
        public int Id { get; set; }
       // [Required]
        public Student Student { get; set; }
       // [Required]
        public Branch Branch { get; set; }
        public DateTime EntryHebrewDate { get; set; }
        public DateTime EntryGregorianDate { get; set; }
        public DateTime ReleaseHebrewDate { get; set; }
        public DateTime ReleaseGregorianDate { get; set; }
        public StudyPath StudyPath { get; set; }
       // [Required]
        public StatusInBranch Status { get; set; }
       // [Required]
        public bool IsActive { get; set; }
    }
}
