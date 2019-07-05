using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,MinLength(2),MaxLength(50)]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public int DialingCode { get; set; }
    }
}