using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IUnitOfWork
{
    public interface ILandingPageServices
    {
         Task<IEnumerable<Cars>> Get10RandomCars();
    }
}
