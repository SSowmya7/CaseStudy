using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IUnitOfWork
{
    public interface IUserFavServices
    {
        Task<IEnumerable<Cars>> GetFavCars(int userId);
        Task<bool> AddFavCar(UserFavourites favourite);
        Task<bool> DeleteFavCar(int userId, string vin);
    }
}
