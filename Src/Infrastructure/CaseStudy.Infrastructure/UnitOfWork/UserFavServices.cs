using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Serilog;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class UserFavServices(IUserFavRepo _userFavRepo,ICarRepo carRepo) : IUserFavServices
    {
        public async Task<IEnumerable<Cars>> GetFavCars(int userId)
        {
            try
            {
                IEnumerable<Cars> cars = await carRepo.GetFavouriteCarsByUserIdAsync(userId);
                return cars;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while retriveing favourite cars at controller level");
                return [];
            }
        }
        public async Task<bool> AddFavCar(UserFavourites favourite)
        {
            try
            {
                await _userFavRepo.AddFavCar(favourite);
                return true;

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while adding favourite cars at controller level");
                return false;
            }
        }
        public async Task<bool> DeleteFavCar(int userId, string vin)
        {
            try
            {
                await _userFavRepo.DeleteFavCar(userId, vin);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while deleting favourite cars at controller level");
                return false;
            }
        }
    }
}
