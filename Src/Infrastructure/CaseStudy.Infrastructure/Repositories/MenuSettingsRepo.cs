using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.Repositories
{
    public class MenuSettingsRepo : IMenuSettingsRepo
    {
        private PrjContext context;
        public MenuSettingsRepo(PrjContext prjContext)
        {
            context = prjContext;
        }


        public async Task<IEnumerable<MenuSettings>> GetMenuSettings()
        {
            try
            {
                return await context.menuSettings.ToListAsync();
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

                var settings= await context.menuSettings.FirstOrDefaultAsync(ms => ms.DealerId == DealerId);
                
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
                var Dealer = await context.dealers.FindAsync(menuSettings.DealerId);
                if(Dealer == null) {
                 return false;
                }
                await context.AddAsync(menuSettings);
                await context.SaveChangesAsync();
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
                var existingMenuSetting = await context.menuSettings
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
                await context.SaveChangesAsync();
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
                var existingMenuSetting = await context.menuSettings
           .FirstOrDefaultAsync(ms => ms.DealerId == DealerId);
                if (existingMenuSetting == null)
                {
                    return false;
                }
                context.menuSettings.Remove(existingMenuSetting);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the menu settings.", ex);
            }
        }










    }
}
