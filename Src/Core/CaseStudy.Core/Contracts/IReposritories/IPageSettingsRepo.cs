using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface IPageSettingsRepo
    {
        Task<IEnumerable<DealerPages>> GetAllPageSettings();

        Task<IEnumerable<DealerPages>> GetPageSettingsById(int dealerId);
        Task<IEnumerable<DealerPages>> GetPageSettingsByPageIdDealerId(int dealerId, int pageId);
        Task<bool> AddPageSettings(DealerPages PageSettings);


        Task<bool> UpdatePageSettings(DealerPages PageSettings);


        Task<bool> DeletePageSettings(int dealerId, int pageId);
    }
}
