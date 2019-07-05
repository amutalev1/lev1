using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public enum Status
    {
        Single = 1,
        Married = 2,
        Divorced = 4,
        widower = 8
    }

    public class StudentChildren
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Student Student { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(0, 120)]
        [RegularExpression(@"^-?[0-9]*\.?[0-9]+$")]
        public decimal Age { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
