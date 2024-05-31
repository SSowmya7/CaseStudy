using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Core.Models
{
    public class Pages
    {
        [Key] public int PageId { get; set; }
        public string PageName {  get; set; }
    }
}
