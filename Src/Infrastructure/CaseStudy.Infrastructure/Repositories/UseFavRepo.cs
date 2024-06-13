using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using CaseStudy.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.Repositories
{
    public class UserFavRepo : IUserFavRepo
    {
        PrjContext context;
        public UserFavRepo(PrjContext prjContext)
        {
            context = prjContext;
        }



        public async Task<IEnumerable<Cars>> GetFavCars(int userId)
        {
            try
            {
               // IEnumerable<Cars> cars = await userFavServices.GetFavCars(userId);
                //return cars;
                throw new NotImplementedException();//this method already exists in carservices
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
                await context.userFavourites.AddAsync(favourite);
                context.SaveChanges();
                return true;
            }
            catch {
                throw new Exception();
                
            }
        }

        public async Task<bool> DeleteFavCar(int userId,string vin)
        {
            try
            {
                UserFavourites userfav = await context.userFavourites
            .Where(uf => uf.UserId == userId && uf.VIN == vin)
            .FirstOrDefaultAsync();
                context.userFavourites.Remove(userfav);
                context.SaveChanges();
                return true;
            }
            catch { }
            {
                throw new Exception();
            }
        }

    }
}
