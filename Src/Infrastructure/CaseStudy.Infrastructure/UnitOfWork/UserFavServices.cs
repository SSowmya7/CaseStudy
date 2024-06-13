using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class UserFavServices : IUserFavServices
    {
        IUserFavRepo userFavRepo;
        public UserFavServices(IUserFavRepo _userFavRepo)
        {
            userFavRepo = _userFavRepo;

        }


        public async Task<IEnumerable<Cars>> GetFavCars(int userId)
        {
            try
            {
                IEnumerable<Cars> cars = await userFavRepo.GetFavCars(userId);
                return cars;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public async Task<bool> AddFavCar(UserFavourites favourite)
        {
            try
            {
                await userFavRepo.AddFavCar(favourite);
                return true;

            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<bool> DeleteFavCar(int userId, string vin)
        {
            try
            {
                 await userFavRepo.DeleteFavCar(userId,vin);
                return true;
            }
            catch { }
            {
                throw new Exception();
            }
        }
    }
}
