using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Serilog;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class LandingPageServices(ICarRepo _carRepo) : ILandingPageServices
    {
       
        public async Task<IEnumerable<Cars>> Get10RandomCars()
        {
            try
            {
                var cars = await _carRepo.Get10RandomCars();
                return cars;
            }
            catch (Exception ex)
            {

                Log.Error(ex, "An error occured while retrieving Cars");
                return [];
            }



        }
    }
}
