using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface IHeaderFooterSettingsRepo
    {
        public  Task<IEnumerable<HeaderAndFooterSettings>> GetHeaderFooterSettings();

        public Task<HeaderAndFooterSettings> GetHeaderFooterSettingsById(int DealerId);

        public Task<bool> AddHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings);


        public  Task<bool> UpdateHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings);


        public  Task<bool> DeleteHeaderAndFooterSettings(int DealerId);
        
    }
}
