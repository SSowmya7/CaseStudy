using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class MenuSettingsServices : IMenuSettingsServices
    {
        private IMenuSettingsRepo MenuSettingsRepo;
        public MenuSettingsServices(IMenuSettingsRepo menuSettings)
        {
            MenuSettingsRepo = menuSettings;

        }
        public async Task<IEnumerable<MenuSettings>> GetMenuSettings()
        {
            try
            {
                return await MenuSettingsRepo.GetMenuSettings();
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

                return await MenuSettingsRepo.GetMenuSettingsById(DealerId);
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
                if (await MenuSettingsRepo.AddMenuSettings(menuSettings))
                {

                    return true;
                };
                return false;
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
               var updateRecord =  await MenuSettingsRepo.UpdateMenuSettings(menuSetting);
                if (!updateRecord)
                {
                    return false;
                }
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
                var deleteRecord = await MenuSettingsRepo.DeleteMenuSettings(DealerId);
                if(deleteRecord == false)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the menu settings.", ex);
            }
        }
    }
}
