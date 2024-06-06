using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Core.Models
{
    public class UserFavourites
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string VIN { get; set; }

    }
}
