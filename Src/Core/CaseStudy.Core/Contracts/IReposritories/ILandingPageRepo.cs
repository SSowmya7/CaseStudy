using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public  interface ILandingPageRepo
    {
        public IEnumerable<DealerPages> GetPageSettings(string PageName);
    }
}
