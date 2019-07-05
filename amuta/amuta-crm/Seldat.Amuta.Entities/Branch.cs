using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seldat.Amuta.Entities.Validations;
using System.Web;

namespace Seldat.Amuta.Entities
{

    public class Branch
    {
        [Flags]
        public enum Includes
        {
            None = 1,
            BranchType = 2,
            UserExtraDetails = 4,
            Address = 8,
            Scolarship = 16,
            Rules = 32,
            ActivityHours = 64,
            Institution = 128
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // [Required]
        public BranchType Type { get; set; }
        // [Required]
        public ExamRules ExamRules { get; set; }
        //I add it
        //[Required]
        public Scolarship Scolarship { get; set; }
        // [Required]
        public AttendanceRules AttendanceRules { get; set; }
        //have to be required
        public UserExtraDetails Head { get; set; }
        // [Required]
        public Address Address { get; set; }
        // [Required]
        //[ MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        //[Required,]
        [DataType(DataType.DateTime)]
        public DateTime OpeningDate { get; set; }
        public int StudentsNumber { get; set; }
        // [Required,] 
        //[MaxLength(500)]
        public string StudySubjects { get; set; }
        //[Required]
        public Institution Institution { get; set; }
        //[Required]
        public string Image { get; set; }
        // [Required]
        public bool IsActive { get; set; }
        public BranchesStudents Students { get; set; }

        public List<BranchDevice> Devices { get; set; }
        public List<BranchExam> Exams { get; set; }
        public List<BranchStaff> Staff { get; set; }
        public List<BranchActivityHours> ActivityHours { get; set; }
        public List<Attendance> BranchAttendances { get; set; }
        public List<HealthSupportRequest> HealthSupportRequests { get; set; }
        public List<DentalHealthSupportRequest> DentalHealthSupportRequests { get; set; }
        public List<FinancialSupportRequest> FinancialSupportRequests { get; set; }
        public List<LoanSupportRequest> LoanSupportRequests { get; set; }

    }


}