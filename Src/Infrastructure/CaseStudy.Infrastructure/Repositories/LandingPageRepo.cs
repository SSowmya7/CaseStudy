using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;

namespace CaseStudy.Infrastructure.Repositories
{
    public class LandingPageRepo : ILandingPageRepo
    {
       
       
        private readonly ICarServices _carServices;
        public LandingPageRepo( ICarServices services)
        {
            _carServices = services;
            
          
        }
        //public IEnumerable<DealerPages> GetPageSettings(string PageName)
        //{


        //    return context.dealerPages.ToList();
        //}

        public async Task<IEnumerable<Cars>> Get10RandomCars()
        {
            try
            {
                var cars = await _carServices.Get10RandomCars();
                return cars;

            }
            catch 
            {
                throw new Exception();
            }

        }
    }
}

