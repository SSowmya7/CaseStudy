using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CaseStudy.Infrastructure.rep
{
    public class PageSettingsRepo(PrjContext prjContext) : IPageSettingsRepo
    {
        public async Task<IEnumerable<DealerPages>> GetAllPageSettings()
        {

            try
            {
                return await prjContext.DealerPages.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex,"Cannot Fetch PageSettings");
                throw new Exception("Cannot Fetch MenuSettings", ex);


            }

        }

        public async Task<IEnumerable<DealerPages>> GetPageSettingsById(int dealerId)
        {
            try
            {

                var settings = await prjContext.DealerPages.Where(ms => ms.DealerId == dealerId).ToListAsync();

                return settings;
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return [];
            }
        }
        public async Task<IEnumerable<DealerPages>> GetPageSettingsByPageIdDealerId(int dealerId,int pageId)
        {
            try
            {

                var settings = await prjContext.DealerPages.Where(ms => ms.DealerId == dealerId && ms.ComponentId == pageId).ToListAsync();

                return settings;
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return [];
            }
        }

        public async Task<bool> AddPageSettings(DealerPages pageSettings) 
        {
            try
            {
                var Dealer = await prjContext.Dealers.FindAsync(pageSettings.DealerId);
                if (Dealer == null)
                {
                    return false;
                }
                await prjContext.AddAsync(pageSettings);
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }


        public async Task<bool> UpdatePageSettings(DealerPages PageSettings) 
        {
        return true;    
        }


        public async Task<bool> DeletePageSettings(int dealerId,int pageId) 
        {

            try
            {
                var existingPageSetting = await prjContext.DealerPages
           .FirstOrDefaultAsync(ms => ms.DealerId == dealerId && ms.ComponentId == pageId);
                if (existingPageSetting == null)
                {
                    return false;
                }
                prjContext.DealerPages.Remove(existingPageSetting);
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while deleting the page settings.");
                return false;
            }

        }
    }
}
