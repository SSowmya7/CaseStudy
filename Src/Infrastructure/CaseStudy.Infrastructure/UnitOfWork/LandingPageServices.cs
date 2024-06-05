using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class LandingPageServices : ILandingPageServices
    {
        ILandingPageRepo _landingPageRepo;
        public LandingPageServices(ILandingPageRepo landingPageRepo) {

            _landingPageRepo = landingPageRepo;        
        }
        public IEnumerable<DealerPages> GetPageSettings(string landing)
        {
            var PageSettings = _landingPageRepo.GetPageSettings(landing);
            return PageSettings;
        }
    }
}
