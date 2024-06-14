using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.Repositories
{
    public class HeaderFooterSettingsRepo : IHeaderFooterSettingsRepo
    {
        public PrjContext context { get; set; }
        public HeaderFooterSettingsRepo(PrjContext prjContext)
        {
            context = prjContext;
        }

       
        public async Task<IEnumerable<HeaderAndFooterSettings>> GetHeaderFooterSettings()
        {
            try
            {
                var settings = await context.HeaderAndFooterSettings.ToListAsync();
                return settings;
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

                var settings = await context.HeaderAndFooterSettings.FirstOrDefaultAsync(ms => ms.DealerId == DealerId);

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
                var Dealer = await context.dealers.FindAsync(headerAndFooterSettings.DealerId);
                if (Dealer == null)
                {
                    return false;
                }
                await context.HeaderAndFooterSettings.AddAsync(headerAndFooterSettings);
                await context.SaveChangesAsync();
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
                var existingMenuSetting = await context.HeaderAndFooterSettings
           .FirstOrDefaultAsync(ms => ms.DealerId == headerAndFooterSettings.DealerId);
                if (existingMenuSetting == null)
                {
                    return false;
                }
                if (headerAndFooterSettings.HeaderLogoImageUrl!= null)
                {
                    existingMenuSetting.HeaderLogoImageUrl = headerAndFooterSettings.HeaderLogoImageUrl;
                }
                if (headerAndFooterSettings.HeaderColor != null)
                {
                    existingMenuSetting.HeaderColor = headerAndFooterSettings.HeaderColor;
                }
                if (headerAndFooterSettings.FooterStyle != null)
                {
                    existingMenuSetting.FooterStyle = headerAndFooterSettings.FooterStyle;
                }
                await context.SaveChangesAsync();
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
                var existingHeaderAndFooterSettings = await context.HeaderAndFooterSettings
           .FirstOrDefaultAsync(ms => ms.DealerId == DealerId);
                if (existingHeaderAndFooterSettings == null)
                {
                    return false;
                }
                context.HeaderAndFooterSettings.Remove(existingHeaderAndFooterSettings);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the HeaderAndFooterSettings.", ex);
            }
        }

    }
}