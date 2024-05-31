using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Core.Models
{
    public class Components
    {
        [Key]public int ComponentId { get; set; } 
        public string? ComponentName { get; set; }
    }
}
