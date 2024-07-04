using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CaseStudy.Infrastructure.Repositories
{
    public class HeaderFooterSettingsRepo(PrjContext _context) : IHeaderFooterSettingsRepo
    {
       

        public async Task<IEnumerable<HeaderAndFooterSettings>> GetHeaderFooterSettings()
        {
            try
            {
                var settings = await _context.HeaderAndFooterSettings.ToListAsync();
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Fetch MenuSettings");
                return [];

            }
        }
        public async Task<HeaderAndFooterSettings> GetHeaderFooterSettingsById(int dealerId)
        {
            try
            {

                var settings = await _context.HeaderAndFooterSettings.FirstOrDefaultAsync(ms => ms.DealerId == dealerId);

                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Fetch MenuSettings");
                return null;

            }
        }
        public async Task<bool> AddHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            try
            {
                var Dealer = await _context.dealers.FindAsync(headerAndFooterSettings.DealerId);
                if (Dealer == null)
                {
                    return false;
                }
                await _context.HeaderAndFooterSettings.AddAsync(headerAndFooterSettings);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An Error occured while Adding MenuSettings");
                return false;

            }
        }

        public async Task<bool> UpdateHeaderAndFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            try
            {
                var existingMenuSetting = await _context.HeaderAndFooterSettings
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
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An Error occured while updating MenuSettings");
                return false;

            }
        }

        public async Task<bool> DeleteHeaderAndFooterSettings(int dealerId)
        {
            try
            {
                var existingHeaderAndFooterSettings = await _context.HeaderAndFooterSettings
           .FirstOrDefaultAsync(ms => ms.DealerId == dealerId);
                if (existingHeaderAndFooterSettings == null)
                {
                    return false;
                }
                _context.HeaderAndFooterSettings.Remove(existingHeaderAndFooterSettings);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An Error occured while deleting MenuSettings");
                return false;

            }
        }

    }
}