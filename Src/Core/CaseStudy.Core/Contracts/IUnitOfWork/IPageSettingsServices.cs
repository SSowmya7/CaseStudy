﻿using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IUnitOfWork
{
    public interface IPageSettingsServices
    {
        Task<IEnumerable<DealerPages>> GetAllPageSettings();

        Task<IEnumerable<DealerPages>> GetPageSettingsById(int dealerId);
        Task<IEnumerable<DealerPages>> GetPageSettingsByPageIdDealerId(int dealerId, int pageId);

        Task<bool> AddPageSettings(DealerPages PageSettings);


        Task<bool> UpdatePageSettings(DealerPages PageSettings);


        Task<bool> DeletePageSettings(int dealerId, int pageId);
    }
}