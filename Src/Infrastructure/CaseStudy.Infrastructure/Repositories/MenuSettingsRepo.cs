using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.Repositories
{
    public class MenuSettingsRepo(PrjContext prjContext) : IMenuSettingsRepo
    {
        public async Task<IEnumerable<MenuSettings>> GetMenuSettings()
        {
            try
            {
                return await prjContext.MenuSettings.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Fetch MenuSettings", ex);

            }
        }
        public async Task<MenuSettings> GetMenuSettingsById(int DealerId)
        {
            try
            {

                var settings= await prjContext.MenuSettings.FirstOrDefaultAsync(ms => ms.DealerId == DealerId);
                
                return settings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot Fetch MenuSettings of the Dealer:- {DealerId}", ex);

            }
        }
        public async Task<bool> AddMenuSettings(MenuSettings menuSettings)
        {
            try
            {
                var Dealer = await prjContext.Dealers.FindAsync(menuSettings.DealerId);
                if(Dealer == null) {
                 return false;
                }
                await prjContext.AddAsync(menuSettings);
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> UpdateMenuSettings(MenuSettingsDTO menuSetting)
        {
            try
            {
                var existingMenuSetting = await prjContext.MenuSettings
           .FirstOrDefaultAsync(ms => ms.DealerId == menuSetting.DealerId);
                if (existingMenuSetting == null)
                {
                    return false;
                }
                if (menuSetting.MenuType != null)
                {
                    existingMenuSetting.MenuType = menuSetting.MenuType;
                }
                if (menuSetting.SrpFilterPosition != null)
                {
                    existingMenuSetting.SrpFilterPosition = menuSetting.SrpFilterPosition;
                }
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the menu settings.", ex);
            }
        }

        public async Task<bool> DeleteMenuSettings(int DealerId)
        {
            try
            {
                var existingMenuSetting = await prjContext.MenuSettings
           .FirstOrDefaultAsync(ms => ms.DealerId == DealerId);
                if (existingMenuSetting == null)
                {
                    return false;
                }
                prjContext.MenuSettings.Remove(existingMenuSetting);
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the menu settings.", ex);
            }
        }










    }
}
