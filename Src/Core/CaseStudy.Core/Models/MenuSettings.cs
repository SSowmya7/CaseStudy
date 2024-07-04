using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Core.Models
{
    public class MenuSettings
    {
        [Key] public int Id {  get; set; }
        public int DealerId {  get; set; }
        public string? MenuType {  get; set; }
        public string? SrpFilterPosition { get; set; }
        
        
    }
}
