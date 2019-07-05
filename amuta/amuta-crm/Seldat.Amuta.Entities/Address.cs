using Seldat.Amuta.Entities.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seldat.Amuta.Entities
{
    public class Address
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       // [Required,ValidateObject]
        public Country Country { get; set; }

        //[Required,ValidateObject]
        public City City { get; set; }

       // [MinLength(2), MaxLength(50)]
        public string NeighborhoodName { get; set; }

       // [Required,ValidateObject]
        public Street Street { get; set; }

        //[Required]
       // [Range(1,1000)]
        public int HouseNumber { get; set; }

        //[Range(1,1000)]
        public int? ApartmentNumber { get; set; }

        //[MinLength(2),MaxLength(25)]
        public string ZipCode { get; set; }

    }
}