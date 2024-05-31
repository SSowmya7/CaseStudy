using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Core.Models
{
    public class Cars
    {
        [Key]
        public int HomeNetVehicleId { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }

        [Required]
        [StringLength(255)]
        public string VIN { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(255)]
        public string? Make { get; set; }

        [Required]
        [StringLength(255)]
        public string? Model { get; set; }

        [Required]
        [StringLength(255)]
        public string? Body { get; set; }

        [StringLength(255)]
        public string? Trim { get; set; }

        [StringLength(255)]
        public string? Transmission { get; set; }

        [StringLength(255)]
        public string? InteriorColor { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SellingPrice { get; set; }
    }
}
