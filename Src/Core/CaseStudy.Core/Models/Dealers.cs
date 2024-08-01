using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Core.Models
{
    public class Dealers
    {
       [Key] public int DealerId { get; set; }
        public string? DealerName { get; set; }
    }
}
