using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public class Bank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required,MinLength(2),MaxLength(20)]
        public string BankNumber { get; set; }

        //[Required,MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        //[Required, Range(0,1000)]
        public string BranchNumber { get; set; }

        public Address Address { get; set; }
    }
}