using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface IHeaderFooterSettingsRepo
    {
        Task<IEnumerable<HeaderAndFooterSettings>> GetHeaderFooterSettings();

        Task<HeaderAndFooterSettings> GetHeaderFooterSettingsById(int dealerId);

        Task<bool> AddHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings);


        Task<bool> UpdateHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings);


        Task<bool> DeleteHeaderAndFooterSettings(int dealerId);

    }
}
