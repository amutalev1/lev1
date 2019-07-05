using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
    public class StudentPayment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Student Student { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int PaymentSum { get; set; }
        public int AttendanceSum { get; set; }
        public int ExamsSum { get; set; }
        public int StateBudgetSum { get; set; }
        public int HealthSupportSum { get; set; }
        public int DentalHealthSupportSum { get; set; }
        public int FinancialSupportSum { get; set; }
        public int LoansGivenSum { get; set; }
        public int LoansReturnSum { get; set; }

    }
}
