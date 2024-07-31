using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Serilog;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class PageSettingsServices(IPageSettingsRepo repo):IPageSettingsServices
    {
        public async Task<IEnumerable<DealerPages>> GetPageSettings()
        {

            try
            {
                return await repo.GetAllPageSettings();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "cannot fecth Page settings at services level");
                throw new Exception("Cannot Fetch PageSettings", ex);

            }
        }
        public async Task<DealerPages> GetPageSettingsById(int dealerId)
        {
            try
            {

                return await repo.GetPageSettingsById(dealerId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Cannot Fetch PageSettings of the Dealer:- {dealerId}");

                return null;
            }
        }
        public async Task<bool> AddPageSettings(DealerPages NewPageSettings)
        {
            try
            {
                if (await repo.AddPageSettings(NewPageSettings))
                {

                    return true;
                };
                return false;
            }
            catch(Exception ex) 
            {

                Log.Error(ex, $"Cannot Add New Page Settings");
                return false;
            }
        }

        public async Task<bool> UpdatePageSettings(DealerPages PageSetting)
        {
            try
            {
                var updateRecord = await repo.UpdatePageSettings(PageSetting);
                if (!updateRecord)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"Cannot update  Page Settings");
                return false;
            }
        }

        public async Task<bool> DeletePageSettings(int dealerId, int pageId)
        {
            try
            {
                var deleteRecord = await repo.DeletePageSettings(dealerId,pageId);
                if (deleteRecord == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"Cannot delete  Page Settings");
                return false;
            }
        }
    }
}
