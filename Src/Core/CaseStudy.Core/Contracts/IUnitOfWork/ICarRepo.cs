using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IUnitOfWork
{
    public interface ICarRepo
    {
        Task<IEnumerable<Cars>> Get10RandomCars();

        Task<IEnumerable<Cars>> GetAllCars();

        Task<Cars?> GetCarByVin(string vin);

        Task<IEnumerable<Cars>> GetSimilarCarsAsync(string vin);


        Task<IEnumerable<Cars>> GetFavouriteCarsByUserIdAsync(int userId);

        Task<IEnumerable<Cars>> GetCarsByFiltersAsync(string make = null, string model = null, int? year = null, string color = null);


    }
}
