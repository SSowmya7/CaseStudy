using CaseStudy.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Application.DTOS
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string? EmailId { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string? PhoneNumber { get; set; } = Constants.Landing;


       
    }
}
