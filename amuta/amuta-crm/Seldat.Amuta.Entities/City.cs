using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public class City
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       // [Required,MinLength(2),MaxLength(50)]
        public string Name { get; set; }

        public Country Country { get; set; }
    }
}