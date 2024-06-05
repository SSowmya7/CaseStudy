using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.Repositories
{
    public class LandingPageRepo : ILandingPageRepo
    {
        PrjContext context;
        public LandingPageRepo(PrjContext prjContext) {

            context = prjContext;
        }
        public IEnumerable<DealerPages> GetPageSettings(string PageName) 
        {

            //var pageSettings = new DealerPages();
            return context.dealerPages.ToList();
        }
    }
}
