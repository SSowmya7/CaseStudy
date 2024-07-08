using CaseStudy.Core.Models;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface IUserFavRepo
    {
       

        Task<bool> AddFavCar(UserFavourites favourite);
        Task<bool> DeleteFavCar(int userId, string vin);
    }
}
