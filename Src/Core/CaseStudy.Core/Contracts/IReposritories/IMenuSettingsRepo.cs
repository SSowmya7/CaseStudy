using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface IMenuSettingsRepo
    {
        public Task<IEnumerable<MenuSettings>> GetMenuSettings();

        public  Task<MenuSettings> GetMenuSettingsById(int DealerId);

        public Task<bool> AddMenuSettings(MenuSettings menuSettings);

        public Task<bool> UpdateMenuSettings(MenuSettingsDTO menuSetting);


        public Task<bool> DeleteMenuSettings(int DealerId);
       
    }
}
