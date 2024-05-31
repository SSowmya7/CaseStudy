namespace CaseStudy.Core.Models
{
    public class HeaderAndFooterSettings
    {
        public int Id {  get; set; }
        public int DealerId {  get; set; }
        public string? HeaderLogoImageUrl {  get; set; }
        public string? HeaderColor { get; set; }
        public string? FooterStyle { get; set; }
    }
}
