using Seldat.Amuta.Entities.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public class Student
    {
        [Flags]
        public enum Includes
        {
            None = 1,
            Children = 2,
            Branch = 4,
            BranchStudent = 8,
            Bank = 16,
            Address = 32,
            AllDetailsBranchStudent = Branch | BranchStudent,
            All = Children | Bank | Address | Branch | BranchStudent

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required,] 
        //[MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        //[Required, ]
        //[MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        //[Required]
        //[RegularExpression(@"[\d]{9,20}", ErrorMessage = "IdentityNumber must contain just digits,length between 9-20")]
        public string IdentityNumber { get; set; }

        //[Required]
        public string IdCard { get; set; }

        //[Required,]
        [ValidateObject]
        public Address Address { get; set; }

        //[Required]
        //[DataType(DataType.Date),RangeDate]
        public DateTime? BornDate { get; set; }

        public string Image { get; set; }

        //[RequiredPhone,]
        //[MinLength(9)]
       // [RegularExpression("^[0-9]*$", ErrorMessage = "PhoneNumber contains only digits")]
        public string PhoneNumber { get; set; }

        //[MinLength(9)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "PhoneNumber contains only digits")]
        public string CellphoneNumber { get; set; }

        //[Required,]
        [ValidateObject]
        public Bank Bank { get; set; }

        //[Required]
        //[MinLength(5),MaxLength(25)]
        public string AccountNumber { get; set; }

        public int? ChildrenNumber { get; set; }

        public int? MarriedChildrenNumber { get; set; }

       // [MinLength(2), MaxLength(50)]
        public string WifeName { get; set; }

        //[MinLength(2), MaxLength(50)]
        public string JobWife { get; set; }

       // [Range(0, 1000000)]
       // [RegularExpression(@"^-?[0-9]*\.?[0-9]+$")]
        public decimal? MonthlyIncome { get; set; }

        public string MonthlyIncomeCurrency { get; set; }

        //[Range(0, 10000),RegularExpression(@"^-?[0-9]*\.?[0-9]+$")]
        public decimal? TravelExpenses { get; set; }

        public string TravelExpensesCurrency { get; set; }
       

       // [MinLength(9)]
       // [RegularExpression("^[0-9]*$", ErrorMessage = "FaxNumber contains only digits")]
        public string FaxNumber { get; set; }

        public bool IsActive { get; set; }       

        public List<StudentChildren> StudentChildren { get; set; }
        public BranchesStudents StudentBranches { get; set; }
        
    }
}

