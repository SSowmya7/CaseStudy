using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class HeaderFooterSettingsServices(IHeaderFooterSettingsRepo headerFooterSettingsRepo) : IHeaderFooterSettingsServices
    {
        public async Task<IEnumerable<HeaderAndFooterSettings>> GetHeaderFooterSettings()
        {
            try
            {
                return await headerFooterSettingsRepo.GetHeaderFooterSettings();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Fetch MenuSettings", ex);

            }
        }
        public async Task<HeaderAndFooterSettings> GetHeaderFooterSettingsById(int dealerId)
        {
            try
            {

                var settings = await headerFooterSettingsRepo.GetHeaderFooterSettingsById(dealerId);

                return settings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot Fetch HeaderAndFooterSettings of the Dealer:- {dealerId}", ex);

            }
        }
        public async Task<bool> AddHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            try
            {
                var addrecord = await headerFooterSettingsRepo.AddHeaderAndFooterSettings(headerAndFooterSettings);
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
               
                var updatedrecord = await headerFooterSettingsRepo.UpdateHeaderAndFooterSettings(headerAndFooterSettings);
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

        public async Task<bool> DeleteHeaderAndFooterSettings(int dealerId)
        {
            try
            {
                var deletedRecord = await headerFooterSettingsRepo.DeleteHeaderAndFooterSettings(dealerId);
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
