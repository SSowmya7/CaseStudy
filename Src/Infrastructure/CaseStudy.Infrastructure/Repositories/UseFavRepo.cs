using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CaseStudy.Infrastructure.Repositories
{
    public class UserFavRepo(PrjContext prjContext) : IUserFavRepo
    {
        public async Task<IEnumerable<Cars>> GetFavCars(int userId)
        {
            try
            {
                // IEnumerable<Cars> cars = await userFavServices.GetFavCars(userId);
                //return cars;
                //throw new NotImplementedException();//this method already exists in carservices
                return [];
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while retriveing cars at repo level");
                return [];
            }
        }
        public async Task<bool> AddFavCar(UserFavourites favourite)
        {
            try
            {
                await prjContext.UserFavourites.AddAsync(favourite);
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while adding user favourite car at repo level");
                return false;
            }
        }

        public async Task<bool> DeleteFavCar(int userId, string vin)
        {
            try
            {
                var userFav = await prjContext.UserFavourites
                    .FirstOrDefaultAsync(uf => uf.UserId == userId && uf.VIN == vin);

                if (userFav == null)
                {
                    return false;
                }

                prjContext.UserFavourites.Remove(userFav);
                await prjContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while deleting user favourite car at repo level");
                return false;
            }
        }

    }
}
