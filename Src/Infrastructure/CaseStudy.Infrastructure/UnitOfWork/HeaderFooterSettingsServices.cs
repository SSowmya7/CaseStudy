using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class HeaderFooterSettingsServices : IHeaderFooterSettingsServices
    {
        private IHeaderFooterSettingsRepo repo;
        public HeaderFooterSettingsServices(IHeaderFooterSettingsRepo headerFooterSettingsRepo)
        {
            repo = headerFooterSettingsRepo;
        }
        public async Task<IEnumerable<HeaderAndFooterSettings>> GetHeaderFooterSettings()
        {
            try
            {
                return await repo.GetHeaderFooterSettings();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Fetch MenuSettings", ex);

            }
        }
        public async Task<HeaderAndFooterSettings> GetHeaderFooterSettingsById(int DealerId)
        {
            try
            {

                var settings = await repo.GetHeaderFooterSettingsById(DealerId);

                return settings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot Fetch HeaderAndFooterSettings of the Dealer:- {DealerId}", ex);

            }
        }
        public async Task<bool> AddHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            try
            {
                var addrecord = await repo.AddHeaderAndFooterSettings(headerAndFooterSettings);
                if (!addrecord)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> UpdateHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            try
            {
               
                var updatedrecord = await repo.UpdateHeaderAndFooterSettings(headerAndFooterSettings);
                if (!updatedrecord)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the HeaderAndFooterSettings.", ex);
            }
        }

        public async Task<bool> DeleteHeaderAndFooterSettings(int DealerId)
        {
            try
            {
                var deletedRecord = await repo.DeleteHeaderAndFooterSettings(DealerId);
                if (!deletedRecord)
                {
                    return false ;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the HeaderAndFooterSettings.", ex);
            }
        }
    }
}
